{
    let a,b,rest;
    [a,b] = [1,2];
    console.log(a, b);
}
{
    let a,b,rest;
    [a,b,...rest] = [1,2,3,4,5,6]
    console.log(a,b,rest);
}
{
    let a,b;
    ({a,b} = {a: 1, b: 2});
    console.log(a,b);
}
{
    let a = 1;
    let b = 2;
    [a,b] = [b,a];
    console.log(a,b);
}
{
    function f() {
        return [1,2]
    }
    let a,b;
    [a,b] = f();
    console.log(a,b);
}
{
    function f(){
        return [1,2,3,4,5]
    }
    let a,b,c;
    [a,,,b] = f();
    console.log(a,b);
}
{
    let o = {p: 42, q: true};
    let {p,q} = o;
    console.log(p,q)
}
{
    let {a=10,b=5} = {a:3};
    console.log(a,b);
}
{
    let metaData = {
        title: 'abc',
        test: [{
            title: 'test',
            desc: 'description'
        }]
    };
    let {title: esTitle,test: [{title:cnTitle}]} = metaData;
    console.log(esTitle,cnTitle);
}
{
    let ajax = function(callBack){
        console.log('exec');
       setTimeout(function(){
         callBack && callBack.call();
       }, 1000)
    };
    ajax(function(){
        console.log('timeout1');
    })
}
{
    let ajax = function(){
       console.log('exec1');
       return new Promise(function(resolve, reject){
          setTimeout(function(){
            resolve();
          }, 1000);
       });
    };
    ajax().then(function(){
        console.log('promise', 'timeout2');
    });
}
{
    let ajax = function(){
        console.log('exec3');
        return new Promise(function(resolve, reject){
           setTimeout(function(){
             resolve();
           }, 1000);
        });
     };
     ajax().then(function(){
        return new Promise(function(resolve, reject){
            setTimeout(function(){
              resolve();
            }, 2000);
         });
     }).then(function(){
        console.log('promise', 'timeout3');
     });
}

{
     function loadImg(src){
         return new Promise((resolve, reject) => {
             let img = document.createElement('img');
             img.src = src;
             img.onload = function(){
                 resolve(img);
             }
             img.onerror = function(err){
                 reject(err);
             }
         })
     }
     function showImages(imgs){
         imgs.forEach(function(img){
             document.body.appendChild(img);
         });
     }
     Promise.all([
         loadImg('http://i4.buimg.com/567571/df1ef0720bea6832.png'),
         loadImg('http://i4.buimg.com/567571/df1ef0720bea6832.png'),
         loadImg('http://i4.buimg.com/567571/df1ef0720bea6832.png')
     ]).then(showImages);
}
{
    let [bar, foo] = [1];
    console.log(bar, foo);
}