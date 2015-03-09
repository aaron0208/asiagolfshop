﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="store.aspx.cs" Inherits="manage_store" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>阿舍高爾夫後台管理系統</title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">

        <!-- Bootstrap -->
        <link rel="stylesheet" media="screen" href="../css/bootstrap.min.css">
        <link rel="stylesheet" media="screen" href="../css/bootstrap-theme.min.css">

        <!-- Bootstrap Admin Theme -->
        <link rel="stylesheet" media="screen" href="../css/bootstrap-admin-theme.css">
        <link rel="stylesheet" media="screen" href="../css/bootstrap-admin-theme-change-size.css">

        <!-- Vendors -->
        <link rel="stylesheet" media="screen" href="../js/bootstrap-datepicker/css/datepicker.css">
        <link rel="stylesheet" media="screen" href="../css/datepicker.fixes.css">
        <link rel="stylesheet" media="screen" href="../js/uniform/themes/default/css/uniform.default.min.css">
        <link rel="stylesheet" media="screen" href="../css/uniform.default.fixes.css">
        <link rel="stylesheet" media="screen" href="../js/chosen.min.css">
        <link rel="stylesheet" media="screen" href="../js/selectize/dist/css/selectize.bootstrap3.css">
        <link rel="stylesheet" media="screen" href="../js/bootstrap-wysihtml5-rails-b3/vendor/assets/stylesheets/bootstrap-wysihtml5/core-b3.css">
        <link rel="stylesheet" media="screen" href="../css/manage.css">
        <link rel="stylesheet" media="screen" href="../css/store.css">
        <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->
        <!--[if lt IE 9]>
           <script type="text/javascript" src="../js/html5shiv.js"></script>
           <script type="text/javascript" src="../js/respond.min.js"></script>
        <![endif]-->
        <script type="text/javascript" src="http://code.jquery.com/jquery-1.8.2.min.js"></script>
        <script type="text/javascript" src="../js/bootstrap.min.js"></script>
        <script type="text/javascript" src="../js/twitter-bootstrap-hover-dropdown.min.js"></script>
        <script type="text/javascript" src="../js/bootstrap-admin-theme-change-size.js"></script>
        <script type="text/javascript" src="../js/uniform/jquery.uniform.min.js"></script>
        <script type="text/javascript" src="../js/chosen.jquery.min.js"></script>
        <script type="text/javascript" src="../js/selectize/dist/js/standalone/selectize.min.js"></script>
        <script type="text/javascript" src="../js/bootstrap-datepicker/js/bootstrap-datepicker.js"></script>
        <script type="text/javascript" src="../js/bootstrap-wysihtml5-rails-b3/vendor/assets/javascripts/bootstrap-wysihtml5/wysihtml5.js"></script>
        <script type="text/javascript" src="../js/bootstrap-wysihtml5-rails-b3/vendor/assets/javascripts/bootstrap-wysihtml5/core-b3.js"></script>
        <script type="text/javascript" src="../js/twitter-bootstrap-wizard/jquery.bootstrap.wizard-for.bootstrap3.js"></script>
        <script type="text/javascript" src="../js/boostrap3-typeahead/bootstrap3-typeahead.min.js"></script>
         <script type="text/javascript" src="../js/ckeditor/ckeditor.js"></script>
        <script type="text/javascript" src="../js/jquery.form.js"></script>
        <script type="text/javascript" src="../js/uploadPreview.js"></script>
        <script type="text/javascript" src="../js/jquery.mu.image.resize.js"></script>
        <script type="text/javascript" src="../manage/js/store.js"></script>
</head>
<body class="bootstrap-admin-with-small-navbar wysihtml5-supported">
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
    <!-- main / large navbar -->
    <nav class="navbar navbar-default navbar-fixed-top bootstrap-admin-navbar bootstrap-admin-navbar-under-small" role="navigation">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".main-navbar-collapse">
                            <span class="sr-only"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                        <a class="navbar-brand" href="./default.aspx">阿舍高爾夫-總後台管理</a>
                    </div>
                    
                </div>
            </div>
        </div><!-- /.container -->
    </nav>
    <div class="container">
        <!-- left, vertical navbar & content -->
        <div class="row">
            <!-- left, vertical navbar -->
            <div class="col-md-2 bootstrap-admin-col-left">
                <ul class="nav navbar-collapse collapse bootstrap-admin-navbar-side">
                    <li>
                        <a href="member.aspx"><i class="glyphicon glyphicon-chevron-right"></i>會員管理</a>
                    </li>
                    <li>
                        <a href="store.aspx"><i class="glyphicon glyphicon-chevron-right"></i>商城管理</a>
                    </li>
                    <li>
                        <a href="bid.aspx"><i class="glyphicon glyphicon-chevron-right"></i>競標管理</a>
                    </li>
                    <li>
                        <a href="secondhand.aspx"><i class="glyphicon glyphicon-chevron-right"></i>二手管理</a>
                    </li>
                    <li>
                        <a href="coach.aspx"><i class="glyphicon glyphicon-chevron-right"></i>教練管理</a>
                    </li>
                </ul>
            </div>
            <!-- content -->
            <div class="col-md-10">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="page-header">
                            <h1>商城管理</h1>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-12">
                        <div class="panel panel-default bootstrap-admin-no-table-panel">
                            <div class="panel-heading">
                                <div class="text-muted bootstrap-admin-box-title"></div>
                                <ul id="myTab" class="nav nav-tabs">
                                    <li class="active"><a href="#categorymanage" data-toggle="tab">產品分類管理</a></li>
                                    <li><a href="#productmanage" data-toggle="tab">產品管理</a></li>
                                   
                                </ul>
                                <div id="myTabContent" class="tab-content">
                                    <div class="tab-pane fade in active" id="categorymanage">
                                        <div class="row">
                                            <div class="col-lg-12">
                                                <div class="panel panel-default bootstrap-admin-no-table-panel">
                                                    <div class="panel-heading">
                                                        <div class="text-muted bootstrap-admin-box-title">新增分類</div>
                                                    </div>
                                                    <div class="bootstrap-admin-panel-content">
                                                        <table class="table table-striped table-bordered" id="Table2">
                                                            <tr>
                                                                <td>分類名稱:</td><td><input type="text" class="cSearch" id="search_account"/></td>
                                                                <td>
                                                                    <button class="btn btn-lg btn-primary" onclick="goSearch()">新增</button>
                                                                    <button class="btn btn-lg btn-primary" onclick="goSearch()">排序</button>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <table class="table table-striped table-bordered" id="Table3">
                                                            <tr>
                                                                <th>分類名稱</th>
                                                                <th>功能</th>
                                                            </tr>
                                                            <tr>
                                                                <td>Drivers 一號木桿</td>
                                                                <td>刪除</td>
                                                            </tr>
                                                        </table>
                                                        
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        
                                        <table class="table table-striped table-bordered" id="example" border="0">
                                        </table>
                                        
                                    </div>
                                    <div class="tab-pane fade " id="productmanage">
                                        <form id="GmyForm" name="GmyForm" action="" method="post" enctype="multipart/form-data">
                                            <table class="table table-striped table-bordered" id="Table1" border="0">
                                                <tr>
			                                        <th width="150">產品編號</th>
			                                        <td><span id="storeID" runat="server"></span></td>
        			                                
			                                        <th rowspan="5" width="200">
			                                            <p align="center">產品照片<br />
        			                                        
			                                                <input id="uploadFile" name="storePhoto" type="file" name="File1" size="1" />
        			                                        
			                                                <br />
			                                                <div id="storePhotoHideDiv" style="display:none;">
			                                                    <img id="storePhotoUrl" href="../images/noAvatar2.jpg" ></img>
			                                                </div>
    			                                            <div id="PhotoShow" href="../images/noAvatar2.jpg" runat="server"></div>
            			                                    
			                                            </p>
			                                           
			                                        </th>
			                                    </tr>
			                                    <tr>
			                                        <th width="150">產品名稱</th>
			                                        <td>
			                                        <input id="storeName" type="text" runat="server" /><span class="startMark">*</span></td>
        			                                
			                                    </tr>
			                                    <tr>
			                                        <th>產品價格</th>
			                                        <td>
			                                            <input id="phone1" type="text" runat="server" /></select><span class="startMark">*</span>
			                                        </td>
        			                                
			                                    </tr>
			                                    <tr>
			                                        <th>產品分類</th>
			                                        <td>
			                                            <select id="Production_Category" runat="server">
			                                               
			                                            </select>
			                                        </td>  
			                                    </tr>
			                                    <tr>
			                                        <th>產品等級</th>
			                                        <td>
			                                            <select id="Select1" runat="server">
			                                                <option>1</option>
			                                                <option>2</option>
			                                                <option>3</option>
			                                                <option>4</option>
			                                                <option>5</option>
			                                            </select>
			                                        </td>  
			                                    </tr>
			                                    <tr>
			                                        <th>產品介紹</th>
			                                        <td>
			                                            <textarea id="Textarea1" rows="5" style="width:95%" runat="server" ></textarea>
			                                        </td>
			                                    </tr>
			                                    <tr>
			                                        <th>完整商品圖文介紹</th>
			                                        <td colspan="5">
			                                            <textarea id="FullIntro" rows="5" style="width:100%" runat="server" ></textarea>
			                                        </td>
			                                    </tr>
        			           
                                            </table>
                                            </form>
                                            <button class="btn btn-lg btn-primary" onclick="updateStore()">更新</button>
                                            <button class="btn btn-lg btn-primary" onclick="updateStore()">預覽</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
