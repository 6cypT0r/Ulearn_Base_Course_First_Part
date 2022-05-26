private static string GetMinX(int a, int b, int c)
{
    if ( a==b && b==0)
	{
		return c.ToString();
	}
	else if (a==0 && b!=0)
	{
		string str = "Impossible";
		return str;
	}
	else if (a != 0)
	{
		double x=(double)b/(-2*(double)a);
		double f_x= (double)a*x*x+ (double)b*x+(double)c;
		return x.ToString();
	}
	else return "impossible";
}
