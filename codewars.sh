#!/bin/bash


mkdir $1
cd $1
cp -r ../Template/* .

#Start default program (visual studio)
start Kata.sln &


