const Ice = require("ice").Ice;
const Test = require("./test").Test;

(async () =>
{
    let communicator;
    try
    {
        communicator = Ice.initialize(process.argv);
        const hello = await Test.RangerAccessRequestPrx.checkedCast(communicator.stringToProxy("test:tcp -h localhost -p 10000"));
        await hello.getResource();
        console.log("ok");
    }
    catch(ex)
    {
        console.log(ex.toString());
        process.exitCode = 1;
    }
    finally
    {
        if(communicator)
        {
            await communicator.destroy();
        }
    }
})();