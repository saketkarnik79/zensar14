import { Project } from "./Project";

const baseUrl='http://localhost:4000';
const url = `${baseUrl}/projects`;

function translateStatusToErrorMessage(status:number): string{
    switch (status){
        case 401:
            return 'Please login again.';
        case 403:
            return 'You do not have permission to view the project(s).';
        default:
            return 'There was an error retrieving the project(s). Please try again.';
    }
}

function checkStatus(response: Response){
    if(response.ok){
        return response;
    }
    else{
        const httpErrorInfo = {
            status: response.status,
            statusText: response.statusText,
            url: response.url
        };

        console.log(`Log server http error: ${JSON.stringify(httpErrorInfo)}`);
        const errorMessage = translateStatusToErrorMessage(httpErrorInfo.status);
        throw new Error(errorMessage);
    }
}

function parseJSON(response: Response){
    return response.json();
}

function delay(ms: number){
    // eslint-disable-next-line @typescript-eslint/no-explicit-any
    return function (x: any): Promise<any>{
        return new Promise((resolve) => setTimeout(() => resolve(x), ms));
    }
}

// eslint-disable-next-line @typescript-eslint/no-explicit-any
function convertToProjectModel(item: any): Project{
    return new Project(item);
}

// eslint-disable-next-line @typescript-eslint/no-explicit-any
function convertToProjectModels(data: any[]): Project[]{
    const projects: Project[] = data.map(convertToProjectModel);
    return projects;
}

const projectAPI = {
    get(page = 1, limit = 9){
        return fetch(`${url}?_page=${page}&_limit=${limit}&_sort=name`)
            .then(delay(600))
            .then(checkStatus)
            .then(parseJSON)
            .then(convertToProjectModels)
            .catch((error: TypeError) => {
                console.log(`Log client error: ${error}`);
                throw new Error('There was an error retrieving the projects. Please try again.');
            })
    },
    put(project: Project){
        return fetch(`${url}/${project.id}`, { 
            method: 'PUT', 
            body: JSON.stringify(project), 
            headers: {'Content-Type': 'application/json'}
        })
            .then(checkStatus)
            .then(parseJSON)
            .catch((error: TypeError) => {
                console.log(`Log client error: ${error}`);
                throw new Error('There was an error retrieving the projects. Please try again.');
            })
    },
    delete(id: number){
        return fetch(`${url}/${id}`, { 
            method: 'DELETE'
        })
            .then(checkStatus)
            .then(parseJSON)
            .catch((error: TypeError) => {
                console.log(`Log client error: ${error}`);
                throw new Error('There was an error retrieving the projects. Please try again.');
            })
    },
    find(id: number){
        return fetch(`${url}/${id}`, { 
            method: 'GET'
        })
            .then(checkStatus)
            .then(parseJSON)
            .then(convertToProjectModel)
            .catch((error: TypeError) => {
                console.log(`Log client error: ${error}`);
                throw new Error('There was an error retrieving the project. Please try again.');
            })
    }
}

export {projectAPI};