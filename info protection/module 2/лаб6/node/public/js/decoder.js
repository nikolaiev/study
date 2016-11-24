//var socket_file;
// var _portFileServer=5666;
//var _protocol=location.protocol=="http:"?"ws":"wss";//https - prefered

var photosPerPage=9//переделать!
var photosObj={};//данные о фотках
var pageNumber=1;//переделать!
var inEditableMode=false;
var photosAmount=0;
var paginatorsAmount=1;
var sex;
var isWoman=false;

//==photoswipe
var pswpElement;
// build items array
var items = [];//changing when load image and destroy
		


	//===============DROPZONE
	var previewNode = document.querySelector("#template");
	previewNode.id = "";
	var previewTemplate = previewNode.parentNode.innerHTML;
	previewNode.parentNode.removeChild(previewNode);

	Dropzone.autoDiscover = false;




	
	var myDropzone = new Dropzone(document.getElementById('DropzoneElementId'),{ // Make the whole body a dropzone
	  url: "/decript", // Set the url
	  thumbnailWidth: 500,
	  thumbnailHeight: 500,
	  parallelUploads: 20,
	  //previewTemplate: previewTemplate,
	  autoQueue: false, // Make sure the files aren't queued until manually added
	  //previewsContainer: "#previews", // Define the container to display the previews
	  clickable: ".fileinput-button", // Define the element that should be used as click trigger to select files.
	  maxFilesize: 5//,//mb
	  //acceptedFiles: ".txt"
	});
	


	myDropzone.on("addedfile", function(file) {
	  // Hookup the start button
		//file.previewElement.querySelector(".start").onclick = function() { myDropzone.enqueueFile(file); };
		document.getElementById('start').onclick = function() { myDropzone.enqueueFile(file); };
		var data={}
		data.file=file;
		var _id=new Date().getTime();

		var defaultCancelButton = Dropzone.createElement('<button class="btn btn-warning btn-xs cancel" id="'+_id+'">\
														<span>Cancel</span>\
													</button> ');		

		
		var alphabet=Dropzone.createElement(
			'<div >\
				<label>\
					<br><br><input type="radio" name="alphabet" value="english" checked> english<br>\
				  	<input type="radio" name="alphabet" value="russian"> russian<br>\
				</label>\
			</div> ')

		
		
		var encTypeButt=Dropzone.createElement(
			'<div  id="enc_type_'+_id+'">\
				<label>\
					<br><br><input type="radio" name="enctype" value="linear" checked> linear<br>\
				  	<input type="radio" name="enctype" value="nonlinear"> nonlinear<br>\
				  	<input type="radio" name="enctype" value="string"> string<br><br>\
				</label>\
			</div> ')



		var encodeDecode=Dropzone.createElement(
			'<div >\
				<label>\
					<br><input type="radio" name="encdirect" value="decode" > decript<br>\
				  	<input type="radio" name="encdirect" value="encode" checked> encript<br>\
				</label>\
			</div> '			
		)
		console.log(defaultCancelButton)
		file.previewElement.appendChild(defaultCancelButton);

		file.previewElement.appendChild(alphabet);	

		file.previewElement.appendChild(encodeDecode)	

		file.previewElement.appendChild(encTypeButt);	


		
	 
		//cansel button
		document.getElementById(_id).onclick=function() {
			  myDropzone.removeFile(data.file);			  
			  //$.post("/api/delfile/photos", { file_id: data.file.id} );
		  };

		 
		/*var rad = document.getElementsByName("encdirect");

	    for(var i = 0; i < rad.length; i++) {
	        rad[i].onclick = function() {
	        	var enctype_id='enc_type_'+_id;
	            if(this.value!="encode"){
	            	//console.log(this.value)
	            	document.getElementById(enctype_id).style.visibility = "hidden";
	            	
	            }
	            else{
	            	document.getElementById(enctype_id).style.visibility = "";
	            }
	        };
	    }*/
	})


    myDropzone.on("processing", function(file) {
    	var encdirect = document.getElementsByName("encdirect");
    	var selectedOpt;
		for(var i = 0; i < encdirect.length; i++) {
		   if(encdirect[i].checked == true) {
		       selectedOpt = encdirect[i].value;
		   }
		 }
		var isEncrypt=selectedOpt=="encode";
		myDropzone.options.url = isEncrypt?"/encript":"/decript";
    });
  

	myDropzone.on('sending', function(file, xhr, formData){

			var enctype = document.getElementsByName("enctype");
			var selectedOpt;
			for(var i = 0; i < enctype.length; i++) {
			   if(enctype[i].checked == true) {
			       selectedOpt = enctype[i].value;
			   }
			 }

            formData.append('enctype', selectedOpt);
			

			var alphabet = document.getElementsByName("alphabet");

			for(var i = 0; i < alphabet.length; i++) {
			   if(alphabet[i].checked == true) {
			       selectedOpt = alphabet[i].value;
			   }
			 }

            formData.append('alphabet', selectedOpt);
        });
		
	myDropzone.on("complete", function(file) {
		myDropzone.removeFile(file);
	});

	
	myDropzone.on("success", function(file, response) {
		file.id=response.id;//sharing file_id
		//TODO upload file back!
		console.log(response)
		text=response.data
		if(response.ext=="txt")
			document.getElementById("result").value = response.data;
		download(response.data,'myfilename.txt', 'text/plain')


		

	});
	function download(text,name, type) {
		  var a = document.getElementById("a");
		  var file = new Blob([text], {type: type});
		  a.href = URL.createObjectURL(file);
		  a.download = name;
		}
	
