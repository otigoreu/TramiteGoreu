using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goreu.Firma.Dto.Requests
{
    public class PDdESRequest
    {
        /// <summary>
        /// PAdES: Para documentos PDF.
        /// XAdES: Para documentos XML.
        /// CAdES: Para cualquier tipo de documento(Firma desacoplada).
        /// </summary>
        public string signatureFormat { get; set; } = "PAdES";


        /// <summary>
        /// B: Firma básica.
        /// T: Firma con sello de tiempo.
        /// LTA: Firma con datos de validación a largo plazo(Long Term Archival).
        /// </summary>
        public string signatureLevel { get; set; } = "B";

        /// <summary>
        /// PAdES: Por defecto es enveloped, se puede enviar en blanco.
        /// XAdES: Por defecto es enveloped, se puede enviar otros valores como: enveloping, detached, internallydetached
        /// CAdES: Por defecto es detached, se puede enviar otro valor como: enveloping.
        /// </summary>
        public string signaturePackaging { get; set; } = "enveloped";

        /// <summary>
        /// URL del documento que se descargará en la PC para firmar. Si la respuesta es un array de bytes se tiene que
        /// indicar en la cabecera de la respuesta el tipo de documento. Para firmar en lote se tiene que enviar un 7z
        /// con los documentos a firmar. En la URL debe de enviar un ID como parte de la URL o una variable de URL, esto para identificar en su servicio
        /// que archivo se va a descargar.
        /// </summary>
        public string documentToSign { get; set; }

        /// <summary>
        /// Expresión regular al CN del certificado. 
        /// ".*": Todos los certificados digitales.
        /// ".*FIR.*|.*FAU.*": Solo certificados de Firma y/o Autenticación.
        /// ".*FIR.*44587589.*": Que sea de firma y contenga el DNI ingresado.
        /// </summary>
        public string certificateFilter { get; set; } = ".*";

        /// <summary>
        /// URL del servicio de sello de tiempo TSA.
        /// </summary>
        public string webTsa { get; set; } = "";

        /// <summary>
        /// Usuario de la TSA. Si no tiene poner ""
        /// </summary>
        public string userTsa { get; set; } = "";

        /// <summary>
        /// Password de la TSA. Si no tiene poner ""
        /// </summary>
        public string passwordTsa { get; set; } = "";

        /// <summary>
        /// Estilo de la interfaz gráfica de usuario: claro, oscuro, claro 2, oscuro 2, claro 3, oscuro 3.
        /// </summary>
        public string theme { get; set; } = "claro";

        /// <summary>
        /// true. Muestra el visor para el posicionamiento visual de la representación gráfica de la firma.
        /// false: No muestra el visor.
        /// </summary>
        public bool visiblePosition { get; set; } = true;

        /// <summary>
        /// Opcional, poner “”. Permite definir un tipo de ID para identificar la firma en el documento al obtener la información de las firmas desde código fuente.
        /// </summary>
        public string contactInfo { get; set; } = "";

        /// <summary>
        /// Texto que indica la Razón de la firma.
        /// </summary>
        public string signatureReason { get; set; } = "Soy el autor de este documento";

        /// <summary>
        /// false: Para realizar una firma simple.
        /// true: Para realizar una firma en lote.
        /// </summary>
        public bool bachtOperation { get; set; } = false;

        /// <summary>
        /// Funciona cuando bachtOperation es true. 
        /// true: El usuario posiciona uno por uno la representación gráfica de la firma.
        /// false: EL usuario posiciona solo una vez la representación gráfica de la firma, tomara esa referencia para las demás.
        /// </summary>
        public bool oneByOne { get; set; } = true;

        /// <summary>
        /// 0: Firma invisible.
        /// 1: Firma con estampado y descripción horizontal.
        /// 2: Firma con estampado y descripción vertical.
        /// 3: Solo firma con estampado.
        /// 4: Solo firma con descripción.
        /// </summary>
        public int signatureStyle { get; set; } = 1;

        /// <summary>
        /// URL la imagen de estampado que se descargará en la PC para la firma. Si la respuesta es un array de bytes se tiene que indicar en la cabecera de la respuesta el tipo de documento. 
        /// La imagen tiene que ser solamente del tipo PNG.
        /// En la URL puede enviar un ID como parte de la URL o una variable de URL, esto para identificar en su servicio que imagen se va a descargar.
        /// </summary>
        public string imageToStamp { get; set; } = "http://localhost:8080/web/doc/stamp.png";

        /// <summary>
        /// Tamaño del texto en el estampado de la firma, valor recomendado 14.
        /// </summary>
        public int stampTextSize { get; set; } = 14;

        /// <summary>
        /// Longitud del texto en el estampado, valor recomendado 37.
        /// </summary>
        public int stampWordWrap { get; set; } = 37;

        /// <summary>
        /// Rol del firmante, es opcional, en caso de no usar enviar ""
        /// </summary>
        public string role { get; set; } = string.Empty; // "Analista de servicios";

        /// <summary>
        /// Página en la que se pondrá el estampado de la firma. Inicia en 1 (solo si visiblePosition es false).
        /// </summary>
        public int stampPage { get; set; } = 1;

        /// <summary>
        /// Posición X en la página donde se pondrá el estampado de la firma(solo si visiblePosition es false)
        /// </summary>
        public int positionx { get; set; } = 20;

        /// <summary>
        /// Posición Y en la página donde se pondrá el estampado de la firma(solo si visiblePosition es false).
        /// </summary>
        public int positiony { get; set; } = 220;

        /// <summary>
        /// URL al cual se realizará POST del documento firmado en la PC del usuario. Se envía el objeto de formulario con nombre “signed_file”. Si son varios documentos firmados retorna un 7z.
        /// En la URL se debe de enviar un ID como parte de la URL o una variable de URL, esto para identificar en su servicio que documento está recibiendo.
        /// </summary>
        public string uploadDocumentSigned { get; set; } = "http://localhost:8080/web/api/upload/162";

        /// <summary>
        /// Único firmante del documento PDF. (CertificationPermission.MINIMAL_CHANGES_PERMITTED). Nadie más podrá agregar una firma digital después.Por defecto es false.
        /// </summary>
        public bool certificationSignature { get; set; } = false;

        /// <summary>
        /// Token de acceso al servicio, este debe ser generado por el integrador en su mismo servidor. (*)
        /// </summary>
        public string token { get; set; }
    }
}
