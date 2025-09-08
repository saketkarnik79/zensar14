'use strict';

/**
 * ES6: Arrow functions
 * Run: node 02-arrow-functions.js
 */

console.log('=== Syntax basics ===');
const add = (a, b) => a + b;
const square = n => n * n; // single param can omit ()
const toUser = (id, name) => ({ id, name }); // return object: wrap in ()

console.log('add(2,3):', add(2, 3));           // -> 5
console.log('square(4):', square(4));          // -> 16
console.log('toUser(7,"Saket"):', toUser(7, 'Saket')); // -> { id: 7, name: 'Saket' }

console.log('\n=== Implicit vs explicit return ===');
const triple = n => n * 3;           // implicit
const tripleVerbose = n => { return n * 3; }; // explicit
console.log(triple(5), tripleVerbose(5)); // 15 15

console.log('\n=== Rest params instead of arguments ===');
const sum = (...nums) => nums.reduce((a, b) => a + b, 0);
console.log('sum(1,2,3,4):', sum(1, 2, 3, 4)); // -> 10

console.log('\n=== Arrow functions do not have their own "arguments" ===');
const tryArguments = () => {
  try {
    // In an arrow, 'arguments' is inherited from an outer non-arrow function (none here)
    return arguments.length; // ReferenceError in strict top-level
  } catch (e) {
    return e.name;
  }
};
console.log('arguments in arrow:', tryArguments()); // -> ReferenceError

console.log('\n=== No own "this" (lexical this) ===');
class List {
  constructor(items) {
    this.items = items;
  }
  renderLater(delayMs = 10) {
    // Arrow preserves 'this' from List
    setTimeout(() => {
      console.log('List items (arrow this):', this.items.join(', '));
    }, delayMs);
  }
  renderLaterWithoutArrow(delayMs = 10) {
    setTimeout(function () {
      // In a plain function, 'this' is undefined (strict mode) or global
      console.log('List items (plain function this):', this && this.items);
    }, delayMs);
  }
}
const list = new List(['alpha', 'beta', 'gamma']);
list.renderLater();              // correct 'this'
list.renderLaterWithoutArrow();  // incorrect 'this' (undefined/global)

console.log('\n=== Arrow as methods — when NOT to use ===');
const counter = {
  count: 0,
  bad: () => { /* 'this' is not 'counter' */ return ++(this.count); },
  good() { return ++this.count; }
};
try {
  console.log('counter.bad():', counter.bad()); // TypeError: Cannot read properties of undefined
} catch (e) {
  console.log('counter.bad() error:', e.name);
}
console.log('counter.good():', counter.good()); // -> 1

console.log('\n=== Arrows cannot be constructors ===');
const NotCtor = () => {};
try {
  // eslint-disable-next-line no-new
  new NotCtor();
} catch (e) {
  console.log('new on arrow throws:', e.name); // -> TypeError
}

console.log('\n=== Arrow functions have no prototype property (constructor behavior) ===');
function Classic() {}
console.log('Classic.prototype exists:', typeof Classic.prototype); // object
console.log('NotCtor.prototype:', NotCtor.prototype);              // undefined

// Keep Node alive briefly to see setTimeout outputs:
setTimeout(() => console.log('\n(Done)'), 30);
