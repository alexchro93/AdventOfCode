/* Probably not the best way to do this but... oh well. */

const util = require('util');
const fs = require('fs');

const inpFile = './DATA1';
const outFile = './INPUT1.DAT';

(function() {
    try {
        const data = fs.readFileSync(inpFile, { encoding: 'utf-8' }); 
        for (let i = 0; i < data.length; i++) {
            fs.appendFileSync(outFile, data.charAt(i) + '\n', { encoding: 'utf-8' });
        }      
    } catch(err) {
        console.log(err);
    }
})();