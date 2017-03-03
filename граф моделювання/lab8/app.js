var express=require("express");
var app=express();
var PORT=3010;
app.use(express.static('public'));

app.listen(PORT,()=>{
	console.log("Server listening on port ",PORT)
});