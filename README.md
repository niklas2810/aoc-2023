# Advent of Code 2023

This repository contains my solutions for this years [Advent of Code](https://adventofcode.com/2023). I already participated a few times:

- [2022](https://github.com/niklas2810/aoc-2022) - C#
- [2021](https://github.com/niklas2810/aoc-2021) - Python
- [2020](https://github.com/niklas2810/aoc-2020) - Java & C++
- [2019](https://github.com/niklas2810/aoc-2019) - Java

## My approach this year

I'll be using C# again, because I don't like last years project setup in retrospect and wanted to tinker with some things! And as always, I don't pressure myself to finish all days! I'll complete the puzzles as long 
as I'm having fun and can afford to spend the time between this, my actual work and other responsibilities in my life 😄

#### C# to Web Application

[Blazor WebAssembly](https://learn.microsoft.com/en-us/aspnet/core/blazor/hosting-models?view=aspnetcore-8.0#blazor-webassembly) is an awesome C# project, 
which allows me to run my solutions both as a command line interface (CLI) and a web application 🥳 It is deployed on each commit and available on [aoc2023.niklasarndt.com](https://aoc2023.niklasarndt.com).

#### Ahead-of-Time (AOT) compilation to native binary

C# works similarly to Java, because both languages require a special runtime to be able to execute the compiled code. Since I'm using .NET 8, I really wanted to try out an option to compile the binary to native code, 
where the required runtime is included in the binary itself (see [Microsoft Docs](https://learn.microsoft.com/en-us/dotnet/core/deploying/native-aot/?tabs=net8plus%2Cwindows)). This has some downsides, e.g. I couldn't
get Reflection to work, because types are stripped when AOT-compiling.

I actively decided _against_ AOT-compilation for the web app, even though it might improve performance a bit. The reason for this is that the application deployed would get a lot bigger, resulting in longer load times. 

#### Unit Testing / GitHub Actions

I also just wanted to play around with MSTest a bit, which doesn't mean I'm targeting some code coverage percentage or something :) Just a few experiments, and I'm especially interested in how to setup the GitHub Actions to run the test automatically. 
Also, I modernized the GitHub Pages deployment I've been using in past projects to use the latest standard.

## AI Disclaimer

I've started using [GitHub Copilot](https://github.com/features/copilot) a few weeks ago and am also using it for this project. 
This means that if you see some comments where I simply copy-pasted an example line or something, it was probably to give Copilot a hint for what I want to do.

I still write 90% of the code myself though (and check the other 10% of course)! For me it's basically a _really_ good autocomplete, it's literally mind-blowing how fast Copilot picks up what you want to do. 

## License

This code is published under MIT License, so feel free to use it as you please (a reference to the source is by license required per-se, but I don't really care)! 

In the same manner, here are some of the projects I'm using:

- [Tabler Icons](https://github.com/tabler/tabler-icons)
- [Pico CSS](https://github.com/picocss/pico)

Because for the love of god, I'm lost when it comes to Web Design 😅
