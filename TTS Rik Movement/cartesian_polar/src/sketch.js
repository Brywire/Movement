let w = 1000;
let h = 600;
let gridstep = 50;

function setup() {
	createCanvas(w, h);
}

function draw() {
	background(192);

	// absolute mousepos snapped to 1/10 grid
	let xpos = mouseX-mouseX%(gridstep/10);
	let ypos = mouseY-mouseY%(gridstep/10);

	drawGrid();
	drawAxes();
	drawLineToMouse(xpos, ypos);
	drawCircleToMouse(xpos, ypos);
	drawData(xpos, ypos);
	drawAngle(xpos, ypos);
	drawNormalized(xpos, ypos);
}

function drawGrid() {
	stroke(128);
	strokeWeight(1);
	textSize(16);
	textAlign(CENTER);
	fill(0);
	for (let x = 0; x < w; x+=gridstep) {
		line(x,0, x,h);
		text(''+(x/50)-10+'', x, (h/2)+20);
	}
	for (let y = 0; y < h; y+=gridstep) {
		line(0,y, w,y);
		text(''+(y/50)-6+'', (w/2)-16, y+5);
	}
}

function drawAxes() {
	stroke(96);
	strokeWeight(3);
	line(w/2,0, w/2,h);
	line(0,h/2, w,h/2);
}

function drawLineToMouse(x, y) {
	stroke(64);
	strokeWeight(2);
	line(w/2,h/2, x,y);
}

function drawCircleToMouse(x, y) {
	let center = createVector(w/2, h/2);
	let endpoint = createVector(x, y);
	let radius = p5.Vector.dist(center, endpoint);

	stroke(64);
	strokeWeight(1);
	noFill();
	ellipse(w/2,h/2, radius*2,radius*2);
}

function drawData(xm, ym) {
	let center = createVector(w/2, h/2);
	let endpoint = createVector(xm, ym);
	let radius = p5.Vector.dist(center, endpoint);

	let vector = createVector(endpoint.x-center.x, endpoint.y-center.y);
	vector.div(50);

	fill(0);
	noStroke();
	textSize(16);
	textAlign(CENTER);
	text('('+vector.x+', '+vector.y+')', xm, ym-8);

	// summary
	textAlign(LEFT);
	text('Vector2: ('+vector.x.toPrecision(2)+', '+vector.y.toPrecision(2)+')', 25, 40);
	text('magnitude: '+vector.mag()+'', 25, 70);
	fill(0,0,255);
	let rad = vector.heading().toPrecision(6);
	let deg = (vector.heading()*180/Math.PI).toPrecision(4);
	text('angle: '+rad+' rad / '+deg+' deg', 25, 100);
	vector.normalize();
	fill(255,0,0);
	text('Vector2 normalized: ('+vector.x.toPrecision(2)+', '+vector.y.toPrecision(2)+')', 25, 130);
}

function drawNormalized(xm, ym) {
	let center = createVector(w/2, h/2);
	let endpoint = createVector(xm, ym);
	let vector = createVector(endpoint.x-center.x, endpoint.y-center.y);
	vector.normalize();

	// red vector
	stroke(255,0,0);
	strokeWeight(4);
	let x = vector.x*50;
	let y = vector.y*50;
	line(w/2, h/2, x + w/2, y + h/2);

	// red circle
	strokeWeight(1);
	noFill();
	ellipse(w/2, h/2, 100, 100);

	// lines
	stroke(255,0,0);
	strokeWeight(1);
	line(x + w/2, h/2, x + w/2, y + h/2);
	line(x + w/2, y + h/2, w/2, y + h/2);
}

function drawAngle(xm, ym) {
	let center = createVector(w/2, h/2);
	let endpoint = createVector(xm, ym);
	let vector = createVector(endpoint.x-center.x, endpoint.y-center.y);
	vector.normalize();

	// blue vector
	stroke(0,0,255);
	strokeWeight(4);
	let x = vector.x*100;
	let y = vector.y*100;

	// blue circle
	strokeWeight(1);
	noFill();
	if (ym < h/2) {
		arc(w/2, h/2, 200, 200, vector.heading(), 0);
	} else if (ym > h/2) {
		arc(w/2, h/2, 200, 200, 0, vector.heading());
	} else if (ym == h/2 && xm < w/2) {
		arc(w/2, h/2, 200, 200, 0, vector.heading());
	}

}
