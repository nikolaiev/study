

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

		
		var keyField=Dropzone.createElement('<div  id="key_val_'+_id+'">\
				<label>\
					<br><br>\
				  	<input type="text" name="keyval" placeholder="key"> key<br>\
				  	\
				</label>\
			</div> ');
		
	
		console.log(defaultCancelButton)
		file.previewElement.appendChild(defaultCancelButton);

		file.previewElement.appendChild(alphabet);	

		file.previewElement.appendChild(keyField);	

		//file.previewElement.appendChild(encodeDecode)	

		//file.previewElement.appendChild(encTypeButt);	


		
	 
		//cansel button
		document.getElementById(_id).onclick=function() {
			  myDropzone.removeFile(data.file);			  
			  //$.post("/api/delfile/photos", { file_id: data.file.id} );
		  };


	})



	myDropzone.on('sending', function(file, xhr, formData){

			var selectedOpt;
			
			var alphabet = document.getElementsByName("alphabet");

			for(var i = 0; i < alphabet.length; i++) {
			   if(alphabet[i].checked == true) {
			       selectedOpt = alphabet[i].value;
			   }
			 }

            formData.append('alphabet', selectedOpt);

            var keyField=document.getElementsByName("keyval");
            var key="1";
            for(var i=0;i<keyField.length;i++){
            	key=keyField[i].value;
            }
            formData.append('key', key);
        });
		
	myDropzone.on("complete", function(file) {
		myDropzone.removeFile(file);
	});

	
	myDropzone.on("success", function(file, response) {
		file.id=response.id;//sharing file_id
		//TODO upload file back!
		console.log(response)
		text=response.data
		if(response.ext=="txt"||response.ext=="err")
			document.getElementById("result").value = response.data;
		download(response.data,'myfilename.txt', 'text/plain')


		

	});
	function download(text,name, type) {
		  var a = document.getElementById("a");
		  var file = new Blob([text], {type: type});
		  a.href = URL.createObjectURL(file);
		  a.download = name;
		}
	
