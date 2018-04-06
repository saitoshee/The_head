#set origin 0.0, 0.0
#set size 0.6,0.95
set encoding utf8
#set xrange[0:44]
#set yrange[0:14]
set nokey 
set title "F1 è F2"
set ylabel "lya"
set xlabel "b"
set border 0
set bar 2
#set ytics ("0.1"0.1,"2.8"2.8,"4.8"4.8,"6.3"6.3,"7.8"7.8,"9.3"9.3,"10.8"10.8,"12.8"12.8,"14.4"14.4,"16.4"16.4,"18.7"18.7)
#set xtics ("0"0,"20"20,"40"40,"60"60,"80"80,"100"100,"120"120,"140"140,"160"160,"180"180,"200"200)
set grid x y
#set ytics 0,150
#set xtics 0,70
plot "sp1.dat" with linespoints linestyle 6