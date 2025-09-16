import { fetchUser } from "../src/UserApi";

describe('Contract test', () => {
    it('validates user schema', async () => {
        global.fetch = jest.fn().mockResolvedValueOnce({
            ok: true,
            json: async () => ({ id: '1', name: 'John Doe' }),
        });
        const user = await fetchUser('1');
        expect(user).toEqual({ id: '1', name: 'John Doe' });
    });

    it('throws on invalid schema', async () => {
        global.fetch = jest.fn().mockResolvedValueOnce({
            ok: true,
            json: async () => ({ id: 1, fullName: 'John Doe' }), // Invalid schema
        });
        await expect(fetchUser('1')).rejects.toThrow();
    });
});