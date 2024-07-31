# Makefile para automatizar a configuração e execução do projeto

.PHONY: setup build migrations infra-local cleanup clean-images

# Variáveis
POSTGRES_IMAGE = postgres

# Configura o ambiente local
setup:
	@echo "Certifique-se de ter o Docker e Docker Compose instalados."
	@echo "Criando e configurando o container PostgreSQL..."
	@docker pull $(POSTGRES_IMAGE)
	@dotnet ef migrations add init

build:
	@echo "Construindo a imagem do Docker..."
	docker build -t taskmanagerapi .

migrations:
	@echo "Aplicando migrations..."
	@docker-compose up -d db db
	@docker-compose up --abort-on-container-exit --exit-code-from migrations migrations

infra-local: setup build migrations
	@echo "Infraestrutura local configurada e migrations aplicadas."

# Para parar e remover o container PostgreSQL
cleanup:
	docker stop $(POSTGRES_CONTAINER_NAME)
	docker rm $(POSTGRES_CONTAINER_NAME)

# Para remover a imagem Docker
clean-images:
	docker rmi taskmanagerapi
