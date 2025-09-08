'use strict';

console.log('=== Block Scope & redeclaration ===');
{
    let a=1;
    const b=2;
    var c=3;
    console.log('Inside block:', a, b, c);
}

try{
    console.log('Outside block:', a);
}
catch(ex){
    console.log('Outside block: a is not defined', ex.name);
}
try{
    console.log('Outside block:', b);
}
catch(ex){
    console.log('Outside block: b is not defined', ex.name);
}
try{
    console.log('Outside block:', c);
}
catch(ex){
    console.log('Outside block: c is not defined', ex.name);
}

console.log('\n=== TDZ(Temporal Dead Zone) ===');
try{
    //Accessing let/const before declaration
    console.log(x);
    let x=10;
}
catch(ex){
    console.log('Accessing let before declaration: ', ex.name);
}

console.log('\n=== var hoisting for comparison ===');
console.log(y);
var y=20;

console.log('\n=== Reassignment rules ===');
let p=100;
p=200; //Reassignment allowed
console.log('Reassigned let p:', p);

const q=300;
try{
    q=400; //Reassignment not allowed
}
catch(ex){
    console.log('Reassigning const q error:', ex.name);
}
console.log('Const q remains:', q);


const varFns = [];
for (var i = 0; i < 3; i++) {
  varFns.push(() => i);
}
console.log(varFns.map(fn => fn()));

const letFns = [];
for (let j = 0; j < 3; j++) {
  letFns.push(() => j);
}
console.log(letFns.map(fn => fn()));
