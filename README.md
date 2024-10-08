# Console

CLI
```
./bomber \
    --Cookies example.com \
    --BaseAddress http://example.com \
    --RequestUri /{0} \
    --Method POST \
    --Start 10 \
    --Count  10 
```

Docker
```
docker build --pull --rm -f "Program.dockerfile" -t bomber:latest "."
docker run -ti --rm bomber:latest \
    -cookies example.com \
    -b http://example.com \
    -m POST \
    -r /{0} \
    -s 10 \
    -c  10    
``` 


dotnet add tests/Tests.csproj reference app/Program.csproj
