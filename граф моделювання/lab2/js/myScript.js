var trace1
$(document).ready(()=>{

Plotly.d3.csv('https://raw.githubusercontent.com/plotly/datasets/master/3d-scatter.csv', function(err, rows){
function unpack(rows, key) {
	return rows.map(function(row)
	{ return row[key]; });}


	z1 = [
	    [8.83,8.89,8.81,8.87,8.9,8.87]]
	    

trace1 = {
	 x: unpack(rows, 'x2'),
	 z: unpack(rows, 'z2'),

	
	type: 'surface'
};



var data = [trace1];
var layout = {margin: {
	l: 0,
	r: 0,
	b: 0,
	t: 0
  }};
Plotly.newPlot('myDiv', data, layout);
});
})