# windows-foucus-monitor
a tool that can monotor which program get the foucs

这个东东用来监视windows哪个应用程序获取了当前输入或者鼠标焦点。

为什么要写这个东西呢？因为有一条我发现我的电脑经常奇迹般的失去焦点！

玩游戏突然退出全屏，聊qq突然输入法弹出框飞了，忍无可忍就写了这个东东，他会监视哪个窗口获取了焦点，并记录日志，显示窗口名，进程名，和时间等信息，可以很方便的揪出来那个偷走焦点的家伙。

因为用到了全局钩子，部分杀毒软件可能又警告，忽略即可，本人以源码担保，真的不是病毒

