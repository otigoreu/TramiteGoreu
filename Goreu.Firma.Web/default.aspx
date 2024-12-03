<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Goreu.Firma.Web._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Firma Peru</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <%--<link href="Content/bootstrap.min.css" rel="stylesheet" />--%>

    <!-- Bootstrap 3.3.6 -->
    <link rel="stylesheet" href="wwwroot/AdminLTE-2.3.11/bootstrap/css/bootstrap.min.css" />
    <!-- Font Awesome -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.5.0/css/font-awesome.min.css" />
    <!-- Ionicons -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/ionicons/2.0.1/css/ionicons.min.css" />
    <!-- iCheck for checkboxes and radio inputs -->
    <link rel="stylesheet" href="wwwroot/AdminLTE-2.3.11/plugins/iCheck/all.css" />
    <!-- Select2 -->
    <link rel="stylesheet" href="wwwroot/AdminLTE-2.3.11/plugins/select2/select2.min.css" />
    <!-- Theme style -->
    <link rel="stylesheet" href="wwwroot/AdminLTE-2.3.11/dist/css/AdminLTE.min.css" />
    <!-- AdminLTE Skins. Choose a skin from the css/skins
     folder instead of downloading all of them to reduce the load. -->
    <link rel="stylesheet" href="wwwroot/AdminLTE-2.3.11/dist/css/skins/_all-skins.min.css" />

    <!-- Kartik -->
    <link href="wwwroot/Kartik/css/fileinput.min.css" rel="stylesheet" />
    <link href="wwwroot/Kartik/css/fileinput-rtl.min.css" rel="stylesheet" />
</head>
<body>
    <!-- jQuery 3.6.0 -->
    <script src="Scripts/jquery-3.6.0.min.js"></script>
    <script src="Scripts/bootstrap.bundle.min.js"></script>

    <!-- FirmaPeru -->
    <script src="wwwroot/FirmaPeru/firmaperu.min.js"></script>

    <!-- jQuery 2.2.3 -->
    <script src="wwwroot/AdminLTE-2.3.11/plugins/jQuery/jquery-2.2.3.min.js"></script>
    <!-- Bootstrap 3.3.6 -->
    <script src="wwwroot/AdminLTE-2.3.11/bootstrap/js/bootstrap.min.js"></script>
    <!-- Select2 -->
    <script src="wwwroot/AdminLTE-2.3.11/plugins/select2/select2.full.min.js"></script>
    <!-- InputMask -->
    <script src="wwwroot/AdminLTE-2.3.11/plugins/input-mask/jquery.inputmask.js"></script>
    <script src="wwwroot/AdminLTE-2.3.11/plugins/input-mask/jquery.inputmask.date.extensions.js"></script>
    <script src="wwwroot/AdminLTE-2.3.11/plugins/input-mask/jquery.inputmask.extensions.js"></script>
    <!-- SlimScroll 1.3.0 -->
    <script src="wwwroot/AdminLTE-2.3.11/plugins/slimScroll/jquery.slimscroll.min.js"></script>
    <!-- iCheck 1.0.1 -->
    <script src="wwwroot/AdminLTE-2.3.11/plugins/iCheck/icheck.min.js"></script>
    <!-- FastClick -->
    <script src="wwwroot/AdminLTE-2.3.11/plugins/fastclick/fastclick.js"></script>
    <!-- AdminLTE App -->
    <script src="wwwroot/AdminLTE-2.3.11/dist/js/app.min.js"></script>
    <!-- AdminLTE for demo purposes -->
    <script src="wwwroot/AdminLTE-2.3.11/dist/js/demo.js"></script>

    <!-- Kartik -->
    <script src="wwwroot/Kartik/js/fileinput.min.js"></script>
    <script src="wwwroot/Kartik/js/count.js"></script>
    <script src="wwwroot/Kartik/js/locales/es.js"></script>

    <section class="content">
        <div class="row">
            <div class="col-md-6">
                <div class="box box-primary">
                    <div class="box-header with-border">
                        <h3 class="box-title"><i class="fa fa-tags"></i>&nbsp;SUBIR ARCHIVO PARA FIRMAR</h3>
                    </div>

                    <form role="form">
                        <div class="box-body">
                            <div class="row">
                                <div class="form-group">
                                    <label for="exampleInputFile">Adjunte el archivo [.pdf] a firmar:</label>
                                    <input id="input-pdf" name="pdfFile" type="file" accept="application/pdf" data-language="es" />

                                    <p class="help-block">Solo archivos con extension [.pdf]</p>
                                </div>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
            <div class="col-md-3">
                <div class="box box-danger">
                    <div class="box-header with-border">
                        <h3 class="box-title"><i class="fa fa-tags"></i>&nbsp;FIRMA DOCUMENTO</h3>
                    </div>

                    <form role="form">
                        <div class="box-body">
                            <div class="row">
                                <div class="form-group col-md-12">
                                    <label>Lista de Archivos - NO FIRMADOS</label>
                                    <div class="input-group">
                                        <select id="cbo_archivo" class="form-control select2" style="width: 100%;">
                                            <option value="">Seleccione un archivo</option>
                                        </select>
                                        <span class="input-group-btn">
                                            <button id="btnVer" type="button" class="btn btn-danger btn-flat"><i class="fa fa-file-pdf-o"></i></button>
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group col-md-12">
                                    <button id="btnInicioFirma" type="button" class="btn btn-primary" onclick="sendParam();">INICIAR FIRMA</button>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group col-md-12">
                                    <label>Lista de Archivos - FIRMADOS</label>
                                    <div class="input-group">
                                        <span class="input-group-btn">
                                            <button type="button" class="btn bg-navy btn-flat" onclick="GetsArchivoFirmado_select();"><i class="fa fa-refresh"></i></button>
                                        </span>
                                        <select id="cbo_archivofirmado" class="form-control select2" style="width: 100%;">
                                            <option value="">Seleccione un archivo</option>
                                        </select>
                                        <span class="input-group-btn">
                                            <button id="btnVerFirmado" type="button" class="btn btn-danger btn-flat"><i class="fa fa-file-pdf-o"></i></button>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="box-footer">
                        </div>
                    </form>
                </div>
            </div>
        </div>
        <div class="row">
            <div id="addComponent" style="display: none"></div>
        </div>
    </section>

    <!-- Local -->
    <script src="wwwroot/local/frm/default.js"></script>
</body>
</html>
