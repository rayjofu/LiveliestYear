# Liveliest Year

https://rextester.com/

Generates a list of class Person containing birth year and end year and process the list to determine the year with the most number of people alive.

e.g.
```
                                    1994 --> 1995
                                                               1997 --> 1998 --> 1999
                                             1995 --> 1996
                                                                        1998 --> 1999
                                             1995 --> 1996 --> 1997 --> 1998 --> 1999
                                                                                 1999
         1991 --> 1992 --> 1993
                                                               1997
         1991 --> 1992
                                                                        1998 --> 1999
Liveliest Year = 1999

                           1993 --> 1994 --> 1995 --> 1996
                                                               1997 --> 1998 --> 1999
                  1992 --> 1993 --> 1994 --> 1995 --> 1996 --> 1997 --> 1998 --> 1999
                                                                                 1999
                                                                                 1999
1990 --> 1991
                                                                                 1999
                           1993 --> 1994 --> 1995 --> 1996
         1991 --> 1992 --> 1993 --> 1994 --> 1995 --> 1996 --> 1997 --> 1998 --> 1999
                                                               1997 --> 1998
Liveliest Year = 1999
```
