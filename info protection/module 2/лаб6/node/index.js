const PORT=3010;

var express=require("express");
var app=express();
var multipart = require('connect-multiparty');
var multipartMiddleware = multipart();
var fs=require('fs')

/*var enc=new Encoder("english","linear");
var result=enc.encode("i remember that september");
var result2=enc.decode(result);
console.log(result2)
	return;*/

app.use(express.static(__dirname+'/public'));

app.listen(PORT,(err)=>{
	if(err)
		return console.log("ERROR ON SERVER START!");
	console.log("Server listens on port "+PORT)
});

app.get('/*',(req,res)=>{
	res.sendFile(__dirname+"/public/index.html")
});

//decription
app.post('/decript',multipartMiddleware,(req,res)=>{
	var encType=req.body.enctype;
	var alphabet=req.body.alphabet;
	//TODO разветвление
	console.log(req.files);
	var fileExt=req.files.file.originalFilename.split('.').pop();

	console.log(req.files);
	fs.readFile(req.files.file.path, function (err, data) {
		var buff=new Buffer(data)
		var str=buff.toString('UTF-8');
		var enc=new Encoder(alphabet,encType);

		try{
			var result=enc.encode(str,true);// передаємо напрямок кодування
		}
		catch(e){
				//при невідомому символі
				var data={};
				data.data=e.toString();
				data.ext='err';//можно помянять
				res.send(data)		
				fs.unlink(req.files.file.path);
				return;
		}

		var data={};
		data.data=result;
		data.ext=fileExt;		
		//res.sendFile(req.files.file.path)
		res.send(data)		
		fs.unlink(req.files.file.path);
	});
});


//encription
app.post('/encript',multipartMiddleware,(req,res)=>{
	
	var encType=req.body.enctype;// тип шифрування
	var alphabet=req.body.alphabet;//тип алфавіту
	var fileExt=req.files.file.originalFilename.split('.').pop();//розширення вхідного файлу

	fs.readFile(req.files.file.path, function (err, data) {
		var buff=new Buffer(data)
		var str=buff.toString('UTF-8');
		var enc=new Encoder(alphabet,encType);
		try{
			var result=enc.encode(str,true);// передаємо напрямок кодування
		}
		catch(e){
				//при невідомому символі
				var data={};
				data.data=e.toString();
				data.ext='err';//можно помянять
				res.send(data)		
				fs.unlink(req.files.file.path);
				return;
		}
		var data={};
		data.data=result;
		data.ext=fileExt;
		res.send(data)
		fs.unlink(req.files.file.path);
	});
});

function Encoder(alph,encType){
	alphabet=[];//алфавіт
	t=0;//допоміжна змінна
	key=0;//допоміжна змінна
	size=0;//розмір алфавіту
	
	/**
		функція кодування/ декодування

		str - вхідні дані (текст)
		decode - флаг декодування	 	
	*/
	this.encode=function(str,decode){
		var result="";
		if(encType=="linear"||encType=="nonlinear"){			
			for(var i=0;i<str.length;i++){
				var t=i+1;//порядковий номер в повідомленні
				if(encType=="linear")
					var key=3*t+1;
				else if(encType=="nonlinear")
					var key=-11*t*t+121*t-117;
				
				var index=alphabet.indexOf(str[i]);
				if(index==-1){
					throw new Error('Unknown symmbol! '+ str[i])
				}

				//перевірка шифратор чи дешифратор
				//методи відрізняються лише знаком в формулі
				//(index+key)%size чи (index-key)%size
				if(decode){
					key=-key;
				}
				var resultInd=(index+key)%size;
				if(resultInd>=size){
					resultInd=resultInd%size;
				}
				else if(resultInd<0){
					while(resultInd<0){
						resultInd+=size;
					}
				}
				result+=alphabet[resultInd];
			}

		} 
		else if(encType=="string"){
			var slogan;
			if(alph=="english")
				slogan="super private string";
			else if(alph=="russian"){
				slogan="супер приватная строка";
			}
			for(var i=0;i<str.length;i++){
				var t=i+1;//порядковий номер в повідомленні
				if(t>=slogan.size){
					t=t%slogan.size
				}

				var key=alphabet.indexOf(slogan[t]);
				var index=alphabet.indexOf(str[i]);

				var resultInd=(index+key)%size;
				if(resultInd>=size){
					resultInd=resultInd%size;
				}
				else if(resultInd<0){
					while(resultInd<0){
						resultInd+=size;
					}
				}
				result+=alphabet[resultInd];
			}

		}
		else{
			throw new Error(1);
		}
		//console.log(result)
		return result;
	}


	//ЗАПОВНЕННЯ АЛФАВІТУ
	if(alph=="english"){
		for(var i='A';;i=nextChar(i)){
			alphabet.push(i);
			if(i=='z')
				break;
		}
	}else if(alph=="russian"){
		for(var i='А';;i=nextChar(i)){
			alphabet.push(i);
			if(i=='я')
				break;
		}
	}
	else{
		throw new Error('Unimplemented alphabet '+alph);
	}

	for(var i=0;i<10;i++){
		alphabet.push(i+'');
	}
	alphabet.push(' ','\n','=','-','_','+','*','/','!');
	size=alphabet.length;
	//console.log(this.alphabet);

	/**
		Отримуємо символ з кодом більшим на 1
	*/
	function nextChar(c) {
	    return String.fromCharCode(c.charCodeAt(0) + 1);
	}

	
}
