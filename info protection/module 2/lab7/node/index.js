const PORT=3010;

var express=require("express");
var app=express();
var multipart = require('connect-multiparty');
var multipartMiddleware = multipart();
var fs=require('fs')

/*var enc=new Encoder("english",10);
var result=enc.encode("i remember that september");

enc=new Encoder("english",10/*key* /);
var result2=enc.encode(result);

console.log(result)

console.log(result2)

	return;
*/
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
app.post('/*',multipartMiddleware,(req,res)=>{
	var key=parseInt(req.body.key);
	var alphabet=req.body.alphabet;
	//TODO разветвление
	var fileExt=req.files.file.originalFilename.split('.').pop();

	fs.readFile(req.files.file.path, function (err, data) {
		var buff=new Buffer(data)
		var str=buff.toString('UTF-8');
		var enc=new Encoder(alphabet,key);

		try{
			var result=enc.encode(str);// передаємо напрямок кодування

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




function Encoder(alph,key){
	alphabet=[];//алфавіт
	

	size=0;//розмір алфавіту
	
	/**
		функція кодування/ декодування

		str - вхідні дані (текст)
		decode - флаг декодування	 	
	*/
	this.encode=function(str,flag){


		var result="";
		var gamma=pseudoRand(str.length);
		

		for(var i=0;i<str.length;i++){
			
			var m=alphabet.indexOf(str[i]);
			if(m==-1){
				throw new Error('Unknown symmbol! '+ str[i])
			}
			var l=m ^ gamma[i];
			l=l%size;

			
			result+=alphabet[l];
		}

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
		alphabet.push('ё')
		alphabet.push('Ё')
	}
	else{
		throw new Error('Unimplemented alphabet '+alph);
	}

	for(var i=0;i<10;i++){
		alphabet.push(i+'');
	}

	alphabet.push(' ','\n','=','-','_','+','*','/','!',',','?','.');
	
	size=alphabet.length;

	//console.log(this.alphabet);


	function pseudoRand(leng){
		var num=35593571; // очень большое простое число.
		//key  
		var seed=key/500; // затравка - то самое инициализирующее число.  
		var start_number=10; // основа  
		var counts = new Array();  
		var max_num = 500; // Инт, который не превосходит наше число. У вас 0-9 числа.  
		
		for(var i=0; i<=leng/*1 more that alphabet size*/; i++){  
		 counts[i] = (Math.pow(start_number+i,seed)%num)%max_num;  			
		}

		return counts;
	}
	/**
		Отримуємо символ з кодом більшим на 1
	*/
	function nextChar(c) {
	    return String.fromCharCode(c.charCodeAt(0) + 1);
	}

	
}
