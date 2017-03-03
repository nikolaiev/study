$(document).ready(function(){
	var rowN =parseInt(prompt('rowN'));
	var colN =parseInt(prompt('colN'));
	init(rowN,colN);
	$('#fillIt').click(function(){		
		fillIt(rowN,colN);
	})
	$('#clearIt').click(function(){
		init(rowN,colN);
	})
})

var init = function(rowN,colN){
	var row='';
	var result='';
	
	var counter = 1;
	for(var i=0;i<rowN;i++){		
		for(var j=0 ;j<colN;j++)
			row+='<td>  </td>';
		result+='<tr>'+row+'</tr>';
		row='';
	}
	$('#matrix').html(result);
	
				console.log("gfqewe")
		


}
//Math.abs(x)
var fillIt = function(rowN,colN){
	var a = [];
	var counter = 1;
	for (var i=0;i<rowN;i++)
		a[i]=[];
	/*
	for (var i = 0; i < colN + rowN; i++) {
        if (i < rowN) {
            for (var j = 0; j <= i && j < colN   ; j++) {
				if(!a[i - j])
					a[i - j] = []	
              a  a[i - j][j] = counter++;
            }
        }
        else {
            for (var j = (i - rowN+1); j <= i && j < colN; j++) {
				if(!a[i - j])
					a[i - j] = []
                a[i  - j][j] = counter++;
            }
        }
     }*/
	 for (var i = 0; i < colN + rowN; i++) {
        if (i < rowN) {
            for (var j = 0; j <= i && j < colN; j++) {
                a[i-j][j] = counter++;
            }
        }
        else {
            for (var j = (i - rowN+1); j <= i && j < colN; j++) {
                a[i-j][j] = counter++;
            }
        }
     }
		
	 /*
	 		for (var i=colN+rowN;i>=0;i--)
		if(i > rowN){
			for(var j=colN+rowN-i;j>=0;j--)
					// if( !a[i+j-colN])
						 // a[i+j-colN]=[];
				console.log((i+j-colN)+" "+j+" "+counter)
                //a[i+j-colN][j] = counter++;
		} else {
			
		}*/
	// var ic = 0;
	// var b = 1;
	// for (var i = 0; i < rowN; i++){
		// var k = i;
		// var base = b;
		// var flag = false;
		// for(var j = 0; j < colN; j++){
			// base = base + k;
			// a[i][j] = base;
			// if (parseInt(k)<parseInt(rowN) && !flag)
				// k++;
			// else
			// {
				// flag = true;
				// k--;
			// }
		// }
		// ic++;
		// b += ic;
	//}
	writeIt(a,rowN,colN);
	
}



var writeIt = function(a,rowN,colN){
	var row=''
	var result=''
	for(var i=0;i<rowN;i++){
			if(!a[i])
				a[i] = []		
		for(var j=0 ;j<colN;j++)
			//row+='<td>'+a[rowN - i - 1][j]+'</td>'
			row+='<td>'+a[i][j]+'</td>'
		result+='<tr>'+row+'</tr>'
		row=''
	}
	$('#matrix').html(result)
}