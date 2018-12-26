# HitCommerce
## Core module
This repo is the core module of the **HitCommerce** project. Works as middle between ABP modules (Identity, BackgroundJobs, ...) and HitCommerce sub-modules (Catalog, Payments, ...) and the task of this module is to process the core requests.
### Status
This project is in **very early preview** stage so it's not suggested to use it in any type of projects.
All entities and service are in archetypal stage, so:
* We appreciate any feedback
* We appreciate any Contribution

Feel free and apply your changes. It is our pleasure to accept your helpful PRs.

Considering the project is the infrastructure of the next modules, we refuse to start new projects. Because we need to get a specific architecture in the core layer.

### Development
#### Pre Requirements

- Visual Studio 2017 15.7.0+

#### ABP vNext
ABP vNext is the next generation of the [ASP.NET Boilerplate](https://aspnetboilerplate.com/) web application framework. See the official [announcement](https://abp.io/blog/abp/Abp-vNext-Announcement) or the official [web site (abp.io)](https://abp.io/) for more information.

Because the ABP is not released yet and thanks to wonderful ABP's developers team for lot daily changes, 
ABP and their own modules is located under the `abp` folder as a submodule. That's include our [Storage integration](https://github.com/abpframework/abp/pull/653). PR still not accepted by the ABP (on review stage) but we needs a store management for our Media.

Please, use the [original guide](https://github.com/abpframework/abp) for building ABP.

After the effective changes, we are merging `abp/master` to `hitaspdotnet/abp`. When you want to update to a newer version of ABP, `cd` into the submodule and pull:
```
cd abp
git pull
cd ..
git submodule init
git submodule update
```
Then run the `abp/build-all.ps1` again and don't forget `dotnet restore` at the `HitCommerce` root directory!

### Contribution

HitCommerce is an open source project. Will remain open-source for ever. So, avoid using commercial codes/libraries.