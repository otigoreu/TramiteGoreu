$(document).ready(function () {
    // Evitar la recarga del formulario al hacer clic en "Upload"
    $('#upload-form').on('submit', function (e) {
        e.preventDefault();  // Previene el reinicio del formulario
    });

    

    $("#btnVer").click(async function (e) {
        e.preventDefault();

        var btn = document.getElementById('btnVer');
        btn.disabled = true;

        try {
            const selectedValue = document.getElementById('cbo_archivo').value;

            await viewPdfInPopup(selectedValue);
            await downloadPdfFile(selectedValue);
        } catch (error) {
            alert(error);
        } finally {
            btn.disabled = false;
        }
    });

    $("#btnVerFirmado").click(async function (e) {
        e.preventDefault();

        var btn = document.getElementById('btnVerFirmado');
        btn.disabled = true;

        try {
            const selectedValue = document.getElementById('cbo_archivofirmado').value;

            await viewPdfInPopup(selectedValue, true);
            await downloadPdfFile(selectedValue, true);
        } catch (error) {
            alert(error);
        } finally {
            btn.disabled = false;
        }
    });
    
    Inicializar();
});

//Variables y funciones necesarias para el funcionamiento de Firma Perù:

let
    jqFirmaPeru = null,
    originalText = null;

const
    btn = document.getElementById('btnInicioFirma');

const url = 'http://172.16.11.74:5010'; // 'http://localhost:3010'; // 

function Inicializar() {
    

    jqFirmaPeru = jQuery.noConflict(true);

    initializeFileInput();

    GetsArchivo_select();

    GetsArchivoFirmado_select();

    console.log('jqFirmaPeru', jqFirmaPeru);
}

function initializeFileInput() {
    jqFirmaPeru('#input-pdf').fileinput({
        overwriteInitial: false,
        validateInitialCount: true,
        allowedFileExtensions: ['pdf'],
        maxFileCount: 1,
        showUpload: true,
        uploadUrl: `${url}/api/FileUpdate/upload-pdf`,
        ajaxSettings: {
            type: 'POST',
            dataType: 'json',
            contentType: false,
            processData: false,
        },
        uploadExtraData: function () {
            return {
                // Datos adicionales si es necesario
            };
        }
    })
        .on('fileuploaded', function (event, data) {
            var response = data.response;
            if (response.success) {
                console.log("Archivo subido correctamente:", response.message);

                // Limpiar la selección del archivo sin destruir el componente
                jqFirmaPeru('#input-pdf').fileinput('clear');
                jqFirmaPeru('#input-pdf').fileinput('enable'); // Rehabilitar el botón "Examinar"

                GetsArchivo_select();
            } else {
                console.log("Error al subir el archivo: " + response.message);
            }
        })
        .on('fileuploaderror', function (event, data, msg) {
            console.log(`Error al subir el archivo: ${msg}`);
        });
}

function signatureInit() {
    //Aqui se puede poner un preload
    //alert('PROCESO INICIADO');

    originalText = btn.innerText; // Guarda el texto original del botón
    btn.disabled = true;
    btn.innerText = "Espere..."; // Cambia el texto del botón
}

function signatureOk() {
    //Cancelar el preload
    //alert('DOCUMENTO FIRMADO')

    GetsArchivoFirmado_select();

    btn.disabled = false; // Habilitar el botón en caso de error
    btn.innerText = originalText; // Restaurar el texto original en caso de error
    originalText = null;
}

function signatureCancel() {
    //Cancelar el preload
    alert('OPERACION CANCELADA');

    btn.disabled = false; // Habilitar el botón en caso de error
    btn.innerText = originalText; // Restaurar el texto original en caso de error
    originalText = null;
}

//Funciones del integrador
async function sendParam() {
    const select = document.getElementById('cbo_archivo');
    const param_token = select.value.split('.').slice(0, -1).join('.');

    const param = {
        param_url: `${url}/api/Firma/param`,
        param_token,
        document_extension: 'pdf'
    };

    console.log('==> Param:', param);

    const jsonString = JSON.stringify(param);
    console.log('==> jsonString:', jsonString);

    const base64String = toBase64(jsonString);
    console.log('==> base64String:', base64String);

    const port = '48596';
    await startSignature(port, base64String); // Llamar a la función de firma digital con los datos en Base64
}

function toBase64(str) {
    return btoa(unescape(encodeURIComponent(str)));
}
//--------------------------------------------------------------------------------------------------------------------
function GetsArchivo_select() {
    fetch(`${url}/api/FileUpdate/files`)
        .then(response => {
            if (!response.ok) {
                throw new Error("Error en la red: " + response.status);
            }
            return response.json();
        })
        .then(files => {
            var select = document.getElementById('cbo_archivo');

            // Limpiar las opciones existentes en el select
            select.innerHTML = '';

            // Agregar una opción por defecto (opcional)
            var defaultOption = document.createElement('option');
            defaultOption.value = '';
            defaultOption.textContent = 'Seleccione un archivo';
            select.appendChild(defaultOption);

            files.forEach(function (file) {
                var option = document.createElement('option');
                option.value = file.Path;
                option.textContent = file.Name;
                select.appendChild(option);
            });
        })
        .catch(error => {
            console.error("Error al cargar los archivos:", error);
        });
}

function GetsArchivoFirmado_select() {
    fetch(`${url}/api/FileUpdate/filesFirmado`)
        .then(response => {
            if (!response.ok) {
                throw new Error("Error en la red: " + response.status);
            }
            return response.json();
        })
        .then(files => {
            var select = document.getElementById('cbo_archivofirmado');

            // Limpiar las opciones existentes en el select
            select.innerHTML = '';

            // Agregar una opción por defecto (opcional)
            var defaultOption = document.createElement('option');
            defaultOption.value = '';
            defaultOption.textContent = 'Seleccione un archivo';
            select.appendChild(defaultOption);

            files.forEach(function (file) {
                var option = document.createElement('option');
                option.value = file.Path;
                option.textContent = file.Name;
                select.appendChild(option);
            });
        })
        .catch(error => {
            console.error("Error al cargar los archivos:", error);
        });
}

async function viewPdfInPopup(fileName, Sign = false) {
    const params = new URLSearchParams({
        FileName: fileName,
        Sign,
        FileType: 'application/pdf'
    });

    try
    {
        const response = await fetch(`${url}/api/FileDownload/download?${params.toString()}`, {
            method: 'GET',
            headers: {
                'Accept': 'application/pdf'
            }
        });

        if (!response.ok) {
            console.error(`Error al descargar el archivo: ${response.status} - ${response.statusText}`);
            return;
        }

        // Leemos la respuesta como Blob
        const blob = await response.blob();

        // Creamos una URL temporal para el Blob
        const _url = window.URL.createObjectURL(blob);

        // Abrimos el PDF en una nueva ventana o pestaña
        const popup = window.open(_url, '_blank');
        if (!popup) {
            alert("Permita que las ventanas emergentes se abran para ver el PDF.");
        }

        // Opcional: si deseas revocar la URL después de que la ventana se haya cerrado
        popup.addEventListener('beforeunload', () => window.URL.revokeObjectURL(_url), { once: true });

    } catch (error) {
        console.error("Error en la solicitud de descarga:", error);
    }
}

async function downloadPdfFile(fileName) {
    const params = new URLSearchParams({
        FileName: fileName,          // Reemplaza `fileName` con el nombre de archivo adecuado
        Directory: 'your-directory-name', // Reemplaza con el nombre del directorio si aplica
        FileType: 'application/pdf'
    });

    try {
        const response = await fetch(`${url}/api/FileDownload/download?${params.toString()}`, {
            method: 'GET',
            headers: {
                'Accept': 'application/pdf'
            }
        });

        if (!response.ok) {
            // Manejamos posibles errores (404 o errores del servidor)
            console.error(`Error al descargar el archivo: ${response.status} - ${response.statusText}`);
            return;
        }

        // Leemos la respuesta como un Blob (para manejar el PDF)
        const blob = await response.blob();

        // Creamos un enlace para descargar el archivo PDF
        const _url = window.URL.createObjectURL(blob);
        const a = document.createElement('a');
        a.href = _url;
        a.download = fileName; // nombre de archivo para la descarga
        document.body.appendChild(a);
        a.click();
        a.remove(); // eliminamos el elemento de enlace una vez descargado

        // Liberamos la URL creada
        window.URL.revokeObjectURL(_url);
    } catch (error) {
        console.error("Error en la solicitud de descarga:", error);
    }

}