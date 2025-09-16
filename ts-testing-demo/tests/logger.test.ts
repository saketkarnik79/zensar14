import * as logger from '../src/logger';

describe('logger',()=>{
    it('call console.log', ()=>{
        const spy = jest.spyOn(console, 'log').mockImplementation(() => {});
        logger.log('Hello World');
        expect(spy).toHaveBeenCalledWith('Hello World');
        spy.mockRestore();
    });
})