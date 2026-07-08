using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sensors.Tests;

[TestClass]
public class Async
{
    [TestMethod]
    public void Tasktests()
    {
        var a = 10000000;
        var b = 1000000000;

        //var T = Task.Run(() => Addition(a, b));

        var T = AdditionAsync(a, b);

        for (var i = 0; i < 10000000; i++)
        {
            var c = i;
        }

        //T.Start();
        T.ContinueWith(t =>
        {
            if (t.IsCompletedSuccessfully)
            {

                var r = t.Result;
                Assert.AreEqual(r, a + b);
            }
            else
            {
                var execption = t.Exception;
            }


        });


    }


    [TestMethod]
    public async Task TaskAvecCancellationToken()
    {
        var cancelationTokenSource = new CancellationTokenSource();
        var T = new Task(() =>
        {
            for(var i=0;i<1000000000; i++)
            {
                if(i % 10000000 == 0)
                {
                    if (cancelationTokenSource.Token.IsCancellationRequested)
                    {
                        Console.WriteLine("Annulation demandée");
                        cancelationTokenSource.Token.ThrowIfCancellationRequested();
                    }
                }
       
            }
        });

        T.Start();
        // cancelationTokenSource.CancelAfter(2000);
        await Task.Delay(2000);
        if (!T.IsCompleted)
        {
                cancelationTokenSource.Cancel(true);
        }
    
    }

    [TestMethod]
    public async void TasktestsAsync()
    {
        var a = 10000000;
        var b = 1000000000;

        // Async await
        var r = await AdditionAsync(a, b);
        Assert.AreEqual(r, a + b);

        AdditionAsync(a, b).ContinueWith(t =>
        {
            var r = t.Result;
            Assert.AreEqual(r, a + b);
        });


    }
    [TestMethod]
    public async void TasktestsAsync2()
    {
        var a = 10000000;
        var b = 1000000000;
        var c = 10000000;
        var d = 1000000000;



        var rI = await Task.WhenAll(AdditionAsync(a, b), AdditionAsync(c, d));


        var r = await AdditionAsync(rI[0], rI[1]);


    }
    int Addition(int a, int b)
    {
        int r = 0;
        for (int i = 0; i < a; i++) r++;
        for (int i = 0; i < b; i++) r++;
        return r;
    }

    Task<int> AdditionAsync(int a, int b )
    {
        return Task.Run(() => Addition(a, b));
    }


    async Task<int> AdditionAsyncPlus1(int a, int b)
    {
        var r= await AdditionAsync(a, b) ;
        var r2 = await AdditionAsync(r, 1);
        return r2;
    }


}
