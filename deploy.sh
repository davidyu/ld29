#!/bin/sh

mkdir ../temp
cp -rf ./entry/bin/* ../temp/
git checkout gh-pages
cp -rf ../temp/* ./
rm -rf ../temp
