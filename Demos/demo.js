// @ts-check
/**
 * Adds two numbers.
 * @param {number} a - The first number.
 * @param {number} b - The second number.
 * @returns {number} The sum of the two numbers.
 */
function add(a,b){
    return a+b;
}

add(10,20);
//add("Hello","World");

// @ts-check
/**
 * @typedef {Object} User
 * @property {string} name
 * @property {number} age
 */

/** @type {User} */
const user = { name: "Alice", age: 30 };
