set encoding utf8
set nokey  
set notitle
set ylabel "P/Pmax"
set xlabel "thetta"
set bmargin 4
set grid x y
set title "KSVN(f,GHz)"
set xrange [-100:100]
set yrange [0:0.002]

set term png
set output "H137_f.png"
plot "H137.dat" with lines lt 1 lw 2 lc "black"
