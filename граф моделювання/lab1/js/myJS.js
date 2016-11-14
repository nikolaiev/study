'use strict'
//first line
let x0=1;
let y0=5.5;
let x1=2;
let y1=2;

//second line
let x2=3.3;
let y2=1;
let x3=-2;
let y3=2;
/*

//first line
let W0=1;

let W1=1;
//second line
let W2=1;

let W3=1;*/

let globalData=[];

function fillData(min,max,step){
  emptyData();

  let func1Data=[];
  let func2Data=[];

  for(let i=min;i<max;i+=step){
    let _x1=resolveFunc1(i,true);//true - x
    let _y1=resolveFunc1(i,false);//false - y
    func1Data.push({x:_x1,y:_y1});
    let _x2=resolveFunc2(i,true);
    let _y2=resolveFunc2(i,false);
    func2Data.push({x:_x2,y:_y2});    
  }
  globalData.data.datasets.push({label:'function 1',data:func1Data});
  globalData.data.datasets.push({label:'function 2',data:func2Data});

}

function makeLinesPretty(){
  $.each(globalData.data.datasets, function(i, dataset) {
        dataset.fill=false;
        dataset.borderColor = randomColor(0.4);
        //dataset.backgroundColor = randomColor(0.5);
        dataset.pointBorderColor = randomColor(0.7);
        dataset.pointBackgroundColor = randomColor(0.5);
        dataset.pointBorderWidth = 1;
    });
}

function emptyData(){

  globalData ={
      type: 'line',
      data: {
          datasets: []
      },
      options: {
          scales: {
              xAxes: [{
                  type: 'linear',
                  position: 'bottom'
              }]
          }
      }
  };
}

function resolveFunc1(t,isX){
  if(isX){
    return x0*(1-t)+x1*t
    var a0=x0*W0;
    var b0=x1*W1;    
  }
  else{    
    return y0*(1-t)+y1*t
    var a0=y0*W0;
    var b0=y1*W1;    
  }
  return x0*(1-t)+x1*t
  //return (a0*(1-t)+b0*t)/(W0*(1-t)+W1*t);
}

function resolveFunc2(t,isX){
  if(isX){
    return x2*(1-t)+x3*t
 
    var a0=x2*W2;
    var b0=x3*W3;    
  }
  else{    
    return y2*(1-t)+y3*t
 
    var a0=y2*W2;
    var b0=y3*W3;    
  }
  return (a0*(1-t)+b0*t)/(W2*(1-t)+W3*t);
}


var randomColorFactor = function() {
    return Math.round(Math.random() * 255);
};
var randomColor = function(opacity) {
    return 'rgba(' + randomColorFactor() + ',' + randomColorFactor() + ',' + randomColorFactor() + ',' + (opacity || '.3') + ')';
};

function designator(a1,a2,b1,b2){
  return a1*b2 -a2*b1;
}

function findIntersectionPoint(){
  //X
  // koeff x from fist function
 /* var k1=x1*W1-x0*W0;
  var c1=x0*W0;
  var k2=W1-W0;
  var c2=W0;
  // koeff x from sexond function
  var k3=x3*W3-x2*W2;
  var c3=x2*W2;
  var k4=W3-W2;
  var c4=W2;

  var a1=(k1*k4-k3*k2);
  var b1=(k1*c4-k2*c3);
  var c1=(k4*c1-k3*c2);
  var d1=(c1*c4-c3*c2);
  //a1 u v + b1 u + c1 v + d1 =0
  //Y
  // koeff y from fist function
  var _k1=y1*W1-y0*W0;
  var _c1=y0*W0;
  var _k2=W1-W0;
  var _c2=W0;
  // koeff y from sexond function
  var _k3=y3*W3-y2*W2;
  var _c3=y2*W2;
  var _k4=W3-W2;
  var _c4=W2;

  var a2=(_k1*_k4-_k3*_k2);
  var b2=(_k1*_c4-_k2*_c3);
  var c2=(_k4*_c1-_k3*_c2);
  var d2=(_c1*_c4-_c3*_c2);
  //a2 u v + b2 u + c2 v + d2 =0
  //TODO if a1!=0;
  if(a1!=0){}
  else if(a2!=0){}
  else{
    var des=designator(b1,c1,b2,c2);
    if(des!=0){
      let u=designator(d1,c1,d2,c2)/des;
      console.log('x='+resolveFunc2(u,true));
      console.log('y='+resolveFunc2(u,false));  
    }
    else{
      return console.log('NO INTERSECTION!');
    }
  }*/
var viz=designator((x1-x0),(x2-x3),(y1-y0),(y2-y3));
  console.log('viz='+viz);
  var u=designator((x2-x0),(x2-x3),(y2-y0),(y2-y3))/viz;
  console.log('u='+u);
  var v=designator((x1-x0),(x2-x0),(y1-y0),(y2-y0))/viz;
  console.log('v='+v);

  console.log('x='+resolveFunc2(v,true));
  console.log('y='+resolveFunc2(v,false));

}


window.onload = function() {
    var ctx = document.getElementById("canvas").getContext("2d");
    fillData(-2,2,0.2);
    makeLinesPretty();
    window.myLine = new Chart(ctx, globalData);
    findIntersectionPoint();
};

