
# I've a Github action under .github/workflows/publish.yml, which
# is going to build on every commit on the `release/1.x.x` branch.
# Therfore the release process is simple. Check if master is in 
# good condition. If so increase the version in the Conditions.csproj
# commit and push to master. Afterwards start this script and the
# corresponding NuGet package will be available under:
# https://www.nuget.org/packages/Mwd.Conditions/
git checkout master
git pull
git checkout release/1.x.x
git merge master
git push