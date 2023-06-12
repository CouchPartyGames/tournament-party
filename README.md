# tournament-party
Realtime Tournament Management System written in C# (Asp.net)



```
dotnet run
```

## Docker Compose

Create `.env` in the root directory
```
APPDATA=/Users/YOUR_USER
```

Create certs and run 
```
dotnet dev-certs https --trust
docker-compose up --build
```

## Container Release signatures

All container images and CLI binaries are signed by cosign. See the documentation on how to verify the signatures.

    -----BEGIN PUBLIC KEY-----
    MFkwEwYHKoZIzj0CAQYIKoZIzj0DAQcDQgAEtLl4tHEH5RDwB5aBuYMXHywW/9O6
    Rl21a0Hukn5cFW0udVogVsFURKALt0rSnUeLEvReaGLESXRSVY4/9TK69w==
    -----END PUBLIC KEY-----


## Helm Support (Kubernetes)

Tournament Party is packaged for easy deployment to kubernetes environments using helm. https://github.com/CouchPartyGames/helm-charts

    helm install 
