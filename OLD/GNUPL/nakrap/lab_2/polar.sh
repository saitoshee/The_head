# set terminal pngcairo  transparent enhanced font "arial,10" fontscale 1.0 size 600, 400 
# set output 'polar.2.png'
set clip points
unset border

set dummy t, y
set raxis
#set key fixed right top vertical Right noreverse enhanced autotitle
set polar
set samples 180, 180
set style data lines
set xzeroaxis
set yzeroaxis
set zzeroaxis
set xtics axis in scale 1,0.5 nomirror   autojustify
set ytics axis in scale 1,0.5 nomirror   autojustify
unset rtics
#set trange [ 0.00000 : 6.28319 ] noreverse nowriteback
set trange [-2*pi:2*pi]

DEBUG_TERM_HTIC = 119
DEBUG_TERM_VTIC = 119
set term png
set output "POLAR.png"
plot "H137.dat"