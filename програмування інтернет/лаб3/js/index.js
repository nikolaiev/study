	var mod = (
	function(){
		return {
			MatrixManipulator:function (){
				var operators={
					"+":summ
				};

				this.calculate=function (matr1,matr2,elem){
					var func=operators[elem||matr2];
					return func(matr1,matr2);
				}

				this.addOperator=function(name,func){
					operators[name]=func;
				}

				this.prettyShow=function prettyShow(matr){
					var len=matr.length;
					var spretty="";
					for(var i =0;i<len;i++){
						for(var j=0;j<len;j++){
							spretty+=" "+matr[i][j];
						}
						spretty+='\n';
					}
					//проверка для системы вывода
					if(console&&console.log)
						console.log(spretty)
					else
						print(spretty);
				}

				function summ(matr1,matr2){
					var len=matr1.length;
					
					for(var i =0;i<len;i++){
						for(var j=0;j<len;j++){
							matr1[i][j]+=matr2[i][j];
						}
					}

					return matr1;
				}
			}
		}
	}
)();

//using module
matrix =new mod.MatrixManipulator;


matrix.addOperator("*",function (a,b){
	var aNumRows = a.length, aNumCols = a[0].length,
		bNumRows = b.length, bNumCols = b[0].length,
		m = new Array(aNumRows); 	
	for (var r = 0; r < aNumRows; ++r) {
		m[r] = new Array(bNumCols); 
		for (var c = 0; c < bNumCols; ++c) {
	  		m[r][c] = 0;            
	  		for (var i = 0; i < aNumCols; ++i) {
		    	m[r][c] += a[r][i] * b[i][c];
	  		}
		}
	}
	//prettyShow(m);		
	return m;
});

matrix.addOperator("tr",function (array){
	
	var arrayLength=array.length;

	var newArray = [];
    for(var i = 0; i < arrayLength; i++){
        newArray.push([]);
    };

    for(i = 0; i < arrayLength; i++){
        for(var j = 0; j < arrayLength; j++){
            newArray[j].push(array[i][j]);
        };
    };

    //prettyShow(newArray);
    return newArray;

});


matrix.addOperator("det",function (a){
	var deter;
	deter=  
		  a[0][0]*a[1][1]*a[2][2] 
		+ a[0][1]*a[1][2]*a[2][0] 
		+ a[0][2]*a[1][0]*a[2][1] 
		- a[0][2]*a[1][1]*a[2][0] 
		- a[0][0]*a[1][2]*a[2][1] 
		- a[0][1]*a[1][0]*a[2][2];		

	//console.log(deter);
	return deter;
})

matrix.addOperator("max",function (matr){		
	var len=matr.length;
	var _max=matr[0][0];
	for(var i =0;i<len;i++){
		for(var j=0;j<len;j++){
			_max=_max>matr[i][j]?_max:matr[i][j];
		}
	}

	//console.log(_max);
	return _max;
});

//проверка на единичную матрицу
matrix.addOperator("ones",function (matr){
	var len=matr.length;
	for(var i =0;i<len;i++){
		for(var j=0;j<len;j++){
			if(i==j && matr[i][j]!=1)
				return false;
			if(i!=j && matr[i][j]!=0)
				return false;
		}
	}
	return true;
});


//examples
var test=[[1,2,3],[4,5,6],[7,8,9]];
matrix.calculate(
		test,
		test,
		"*"
		);

matrix.calculate(
		[[1,2,3],[4,5,6],[7,8,9]],
		"det"
		);




//checking for orthogonality
//var matr = [[-1,0,0],[0,-1,0],[0,0,-1]]; //orthogonal
var matr = [[-1,0,0],[0,-1,0],[0,0,-2]];   //non orthogonal
matrix.prettyShow(matr)
//transponation
var matr_trans = matrix.calculate(matr,"tr");

var result = matrix.calculate(matr,matr_trans,"*");

//showing 
matrix.prettyShow(result)
//checking for euality
var resStr="Is matrix orthogonal = "
		//проверка на единичную матрицу
		+ matrix.calculate(result,"ones");

//проверка для системы вывода
if(console&&console.log)
	console.log(resStr)
else
	print(resStr);



