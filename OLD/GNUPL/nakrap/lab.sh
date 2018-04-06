set encoding utf8
set key outside bottom left
set nolabel
set ylabel "KSVN"
set xlabel "f,GHz"
set tics font "Times New Roman,12"
#set style line 1 lt 1 pt 4
#set title "KSVN(f,GHz)"
set xrange [900:3991]
set yrange [1:1.1]
set size 0.8,1
set grid x,y
set term png
set output "one.png"
plot "1b.dat" with lines lt 4 lw 1.5 lc "black" t "KSVN(f,GHz)"