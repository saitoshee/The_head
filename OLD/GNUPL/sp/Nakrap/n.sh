set encoding utf8
set nokey  
set notitle
set ylabel "KSVN"
set xlabel "f,Hz"
set bmargin 4
set style line 1 lt 1 pt 7 
set grid x y
set title "KSVN(f,Hz)"
#set xrange [880:4000]
set term png

set output "a.png"
plot "a.dat" with dots
