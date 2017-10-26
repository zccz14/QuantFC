const liveServer = require("live-server");
const URL = require("url");
const {spawn} = require("child_process");
const path = require('path');

const home = "../QuantFCLab/bin/Debug";

var params = {
    root: home, // Set root directory that's being served. Defaults to cwd. 
    open: false, // When false, it won't load your browser by default. 
    wait: 1000, // Waits for all changes, before reloading. Defaults to 0 sec. 
    logLevel: 2
    middleware: [
        function (req, res, next) {
            if (req.url.match(/.dot$/)) {
                let process = spawn('dot', [path.join(home, req.url), '-T', 'svg']);
                process.stdout.on('data', data => res.write(data));
                process.stderr.on('data', data => console.log(`${data}`));
                process.on('close', () => res.end());
                return;
            }
            next();
        }
    ] // Takes an array of Connect-compatible middleware that are injected into the server middleware stack 
};
liveServer.start(params);
