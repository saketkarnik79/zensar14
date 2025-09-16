import { add, subtract, multiply, divide, modulus }  from '../src/math';
import { describe, expect, test } from '@jest/globals';

describe('Math functions', () => {
    test('adds two numbers', () => {
        expect(add(2, 3)).toBe(5);
    });

    test('subtracts two numbers', () => {
        expect(subtract(5, 3)).toBe(2);
    });

    test('multiplies two numbers', () => {
        expect(multiply(2, 3)).toBe(6);
    });

    test('divides two numbers throws exception when second parameter is 0', () => {
        expect(divide(6, 3)).toBe(2);
    }); 

    test('throws error when dividing by zero', () => {
        expect(() => divide(6, 0)).toThrow("Cannot divide by zero");
    });

    test('divides two numbers', () => { 
        expect(divide(6, 3)).toBe(2);    
    })

    test('throws error when dividing by zero for modulus', () => {
        expect(() => modulus(6, 0)).toThrow("Cannot divide by zero");
    });

    test('divides two numbers and returns modulus', () => { 
        expect(modulus(6, 5)).toBe(1);    
    })
});