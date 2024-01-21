# Microservices Full Course
Microservices full course by binarythistle
github - github.com/binarythistle

## Services
- Platforms
- Command


## Kubernetes Ingress installation

- with Quick start guide  https://kubernetes.github.io/ingress-nginx/deploy/#quick-start 
    can use the yaml manifest approach since HElm is not installed
    - kubectl apply -f https://raw.githubusercontent.com/kubernetes/ingress-nginx/controller-v1.8.2/deploy/static/provider/cloud/deploy.yaml

- use kubectl get commands to check the statuses of pods and services of ingress being installed since it takes time to install on local
    kubectl get pods --namespace=ingress-nginx
- once the controller pod is running the ingress-srv.yaml can be deployed using the below command
    NAME                                            READY   STATUS      RESTARTS   AGE
    pod/ingress-nginx-admission-create-6q25k        0/1     Completed   0          8m19s
    pod/ingress-nginx-admission-patch-dp7qc         0/1     Completed   0          8m19s
    pod/ingress-nginx-controller-8558859656-fzjlf   1/1     Running     0          8m19s

    kubectl apply -f .\ingress-srv.yaml

- can check ingress is running using 
    kubectl get ingress

    NAME          CLASS   HOSTS       ADDRESS     PORTS   AGE
    ingress-srv   nginx   dum.local   localhost   80      10m

