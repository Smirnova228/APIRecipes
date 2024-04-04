from locust import HttpUser, task, between

class MyUser(HttpUser):
    wait_time = between(5, 9)

    @task
    def index(self):
        self.client.get("/")

    @task
    def about(self):
        self.client.get("/about")

    @task
    def products(self):
        self.client.get("/products")

    @task
    def login(self):
        self.client.post("/login", json={"username": "test_user", "password": "password123"})

    @task
    def logout(self):
        self.client.get("/logout")