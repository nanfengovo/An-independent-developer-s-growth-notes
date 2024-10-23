# 将string 类型转换为DataTime 类型一共有三种方式：
## 第一种使用 Convert.ToDataTime(string) 
注意点：
* 日期的格式需要是"yyyy/MM/dd"或"yyyy-MM-dd"*




# [c#中，如何获取日期型字段里的年、月、日？](https://www.cnblogs.com/cnote/p/9094618.html "发布于 2018-05-26 22:41")
```C#
# [c#中，如何获取日期型字段里的年、月、日？](https://www.cnblogs.com/cnote/p/9094618.html "发布于 2018-05-26 22:41")

DateTime.Now.ToShortDateString()   
//只取日期  
DateTime.Now.ToLongTimeString();  
//只取时间  
搞定   
DateTime.Now.ToShortTimeString()  
DateTime dt = DateTime.Now;  
dt.ToString();//2005-11-5 13:21:25  
dt.ToFileTime().ToString();//127756416859912816  
dt.ToFileTimeUtc().ToString();//127756704859912816  
dt.ToLocalTime().ToString();//2005-11-5 21:21:25  
dt.ToLongDateString().ToString();//2005年11月5日  
dt.ToLongTimeString().ToString();//13:21:25  
dt.ToOADate().ToString();//38661.5565508218  
dt.ToShortDateString().ToString();//2005-11-5  
dt.ToShortTimeString().ToString();//13:21  
dt.ToUniversalTime().ToString();//2005-11-5 5:21:25  
dt.Year.ToString();//2005  
dt.Date.ToString();//2005-11-5 0:00:00  
dt.DayOfWeek.ToString();//Saturday  
dt.DayOfYear.ToString();//309  
dt.Hour.ToString();//13  
dt.Millisecond.ToString();//441  
dt.Minute.ToString();//30  
dt.Month.ToString();//11  
dt.Second.ToString();//28  
dt.Ticks.ToString();//632667942284412864  
dt.TimeOfDay.ToString();//13:30:28.4412864  
dt.ToString();//2005-11-5 13:47:04  
dt.AddYears(1).ToString();//2006-11-5 13:47:04  
dt.AddDays(1.1).ToString();//2005-11-6 16:11:04  
dt.AddHours(1.1).ToString();//2005-11-5 14:53:04  
dt.AddMilliseconds(1.1).ToString();//2005-11-5 13:47:04  
dt.AddMonths(1).ToString();//2005-12-5 13:47:04  
dt.AddSeconds(1.1).ToString();//2005-11-5 13:47:05  
dt.AddMinutes(1.1).ToString();//2005-11-5 13:48:10  
dt.AddTicks(1000).ToString();//2005-11-5 13:47:04  
dt.CompareTo(dt).ToString();//0  
dt.Add(?).ToString();//问号为一个时间段  
dt.Equals("2005-11-6 16:11:04").ToString();//False  
dt.Equals(dt).ToString();//True  
dt.GetHashCode().ToString();//1474088234  
dt.GetType().ToString();//System.DateTime  
dt.GetTypeCode().ToString();//DateTime  
    
dt.GetDateTimeFormats('s')[0].ToString();//2005-11-05T14:06:25  
dt.GetDateTimeFormats('t')[0].ToString();//14:06  
dt.GetDateTimeFormats('y')[0].ToString();//2005年11月  
dt.GetDateTimeFormats('D')[0].ToString();//2005年11月5日  
dt.GetDateTimeFormats('D')[1].ToString();//2005 11 05  
dt.GetDateTimeFormats('D')[2].ToString();//星期六 2005 11 05  
dt.GetDateTimeFormats('D')[3].ToString();//星期六 2005年11月5日  
dt.GetDateTimeFormats('M')[0].ToString();//11月5日  
dt.GetDateTimeFormats('f')[0].ToString();//2005年11月5日 14:06  
dt.GetDateTimeFormats('g')[0].ToString();//2005-11-5 14:06  
dt.GetDateTimeFormats('r')[0].ToString();//Sat, 05 Nov 2005 14:06:25 GMT  
string.Format("{0:d}",dt);//2005-11-5  
string.Format("{0:D}",dt);//2005年11月5日  
string.Format("{0:f}",dt);//2005年11月5日 14:23  
string.Format("{0:F}",dt);//2005年11月5日 14:23:23  
string.Format("{0:g}",dt);//2005-11-5 14:23  
string.Format("{0:G}",dt);//2005-11-5 14:23:23  
string.Format("{0:M}",dt);//11月5日  
string.Format("{0:R}",dt);//Sat, 05 Nov 2005 14:23:23 GMT  
string.Format("{0:s}",dt);//2005-11-05T14:23:23  
string.Format("{0:t}",dt);//14:23  
string.Format("{0:T}",dt);//14:23:23  
string.Format("{0:u}",dt);//2005-11-05 14:23:23Z  
string.Format("{0:U}",dt);//2005年11月5日 6:23:23  
string.Format("{0:Y}",dt);//2005年11月  
string.Format("{0}",dt);//2005-11-5 14:23:23  
string.Format("{0:yyyyMMddHHmmssffff}",dt);  
计算2个日期之间的天数差  
-----------------------------------------------  
DateTime dt1 = Convert.DateTime("2007-8-1");     
DateTime dt2 = Convert.DateTime("2007-8-15");    
TimeSpan span = dt2.Subtract(dt1);               
int dayDiff = span.Days + 1;                     
计算某年某月的天数  
-----------------------------------------------     
int days = DateTime.DaysInMonth(2007, 8);        
days = 31;                                       
给日期增加一天、减少一天  
-----------------------------------------------  
DateTime dt =DateTime.Now;  
dt.AddDays(1); //增加一天  
dt.AddDays(-1);//减少一天  
其它年份方法类似...  
Oracle SQL里转换[日期函数](https://www.baidu.com/s?wd=%E6%97%A5%E6%9C%9F%E5%87%BD%E6%95%B0&tn=SE_PcZhidaonwhc_ngpagmjz&rsv_dl=gh_pc_zhidao)  
-----------------------------------------------  
to_date("2007-6-6",'YYYY-MM-DD");  
to_date("2007/6/6",'yyyy/mm/dd");  
如下一组数据,如何查找表里包含9月份的记录:  
CGGC_STRATDATE  CGGC_ENDDATE  
=========================================  
2007-8-4  2007-9-5  
2007-9-5  2007-9-20  
2007-9-22  2007-10-5  
SELECT * FROM TABLE  
(TO_DATE('2007/9/1','yyyy/mm/dd') BETWEEN CGGC_STRATDATE  
AND CGGC_ENDDATE OR CGGC_STRATDATE >=TO_DATE('2007/9/1','yyyy/mm/dd')  
AND CGGC_ENDDATE<=TO_DATE('2007/9/30','yyyy/mm/dd') "  
OR TO_DATE('2007/9/30','yyyy/mm/dd') BETWEEN CGGC_STRATDATE  
AND CGGC_ENDDATE) ORDER BY CGGC_STRATDATE ASC
```

