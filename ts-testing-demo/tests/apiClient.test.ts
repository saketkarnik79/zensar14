import { fetchUser } from "../src/apiClient";
import { afterEach, beforeEach, describe, expect, test, it } from '@jest/globals';

global.fetch = jest.fn();

describe('fetchUser', () => {
   beforeEach(() => {
       jest.clearAllMocks();
   });
   
   it('returns user data', async () => {
     (globalThis.fetch as jest.Mock).mockResolvedValueOnce({
            ok: true,
            json: async () => ({ id: '1', name: 'John Doe' }),
        });
        const user =await fetchUser('1');
        expect(user).toEqual({ id: '1', name: 'John Doe' });
   });

   it('throws on error response', async () => {
        (fetch as jest.Mock).mockResolvedValueOnce({
            ok: false,
        });
        await expect(fetchUser('1')).rejects.toThrow('Failed to fetch user');
   });   
   
   afterEach(() => {
        jest.resetAllMocks();
   });
});