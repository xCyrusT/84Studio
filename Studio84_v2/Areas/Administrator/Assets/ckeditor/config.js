/**
 * @license Copyright (c) 2003-2017, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	config.language = 'en';
	// config.uiColor = '#AADC6E';
    config.filebrowserBrowseUrl = '/Areas/Administrator/Assets/ckfinder/ckfinder.html';
    config.filebrowserImageBrowseUrl = '/Areas/Administrator/Assets/ckfinder/ckfinder.html?type=Images';
    config.filebrowserFlashBrowseUrl = '/Areas/Administrator/Assets/ckfinder/ckfinder.html?type=Flash';
    config.filebrowserUploadUrl = '/Areas/Administrator/Assets/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files';
    config.filebrowserImageUploadUrl = '/Areas/Administrator/Assets/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images';
    config.filebrowserFlashUploadUrl = '/Areas/Administrator/Assets/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';
};
