'use strict'
let HEIGHT
let WIDTH
let matrix=[];

$(document).ready(()=>{
	$('#myButton').hide();
	
	$('#myStartButton').click(()=>{
		//let size=
		let HEIGHT=parseInt($('#myInputH').val());
		let WIDTH=parseInt($('#myInputW').val());
		createStartMatr(HEIGHT,WIDTH);
	})
	$('#myButton').click(()=>{
		task();
	})
})

function showMatrix (isSecond,middle){
	let table;

	if(!isSecond)
		table=$('#myTable');
	else
		table=$('#mySecondTable');

	for(let i=0;i<HEIGHT;i++){
		let row;
		
		if(isSecond && ((i>=middle&&HEIGHT%2==0)||(i>middle-1&&HEIGHT%2==1)))
			row=$('<tr>').attr('class','myTr');
		else if(isSecond && ((i<middle&&HEIGHT%2==0)||(i<middle-1&&HEIGHT%2==1)))
			row=$('<tr>').attr('class','myTrUp');
		else		
			row=$('<tr>');

		table.append(row)

		for (let  j= 0; j < WIDTH; j++){
			row.append($('<td>').html($('<span>').html(matrix[i][j])).attr('class','myTd'));
		}
		
	}
}

function task(){
	let middle=Math.ceil(HEIGHT/2);
	console.log(middle)
	for(let i=0;i<middle;i++){
		for (let  j= 0; j < HEIGHT; j++){
			matrix[HEIGHT-i-1][j]=matrix[i][j];
		}		
	}
	showMatrix(true,middle)
}

function createStartMatr(h,w){
	HEIGHT=h;
	WIDTH=w
	clearAll();
	begin();
}

function clearAll(){
	$('#myTable').empty();
	$('#mySecondTable').empty();
	$('myButton').hide();
}

function begin(){
	for(let i=0;i<HEIGHT;i++){
		matrix[i]=[];
		for (let  j= 0; j < WIDTH; j++){
			matrix[i][j]=Math.ceil(Math.random()*100);		
		}
	}
	$('#myButton').show();
	showMatrix();
}