//import { MOCK_PROJECTS } from "./MockProjects";
import ProjectList from "./ProjectList";
import { Project } from "./Project";
import { useState, useEffect } from "react";
import { projectAPI } from "./projectAPI";

function ProjectsPage(){

    //const [projects, setProjects] = useState<Project[]>(MOCK_PROJECTS);
    const [projects, setProjects] = useState<Project[]>([]);

    const[loading, setLoading] = useState(false);
    const[error, setError] = useState<string | undefined>(undefined);
    const[currentPage, setCurrentPage] = useState(1);

    const handleMoreClick = () => {
        setCurrentPage((currentPage) => currentPage + 1)
    };

    useEffect(() => {
        async function loadProjects(){
            setLoading(true);
            try{
                //const data = await projectAPI.get(1);
                const data = await projectAPI.get(currentPage);
                setError('');
                //setProjects(data);
                if(currentPage === 1){
                    setProjects(data);
                }
                else{
                    setProjects((projects) => [...projects, ...data])
                }
            }
            catch(ex){
                if (ex instanceof Error){
                    setError(ex.message);
                }
            }
            finally{
                setLoading(false)
            }
        }
        loadProjects();
    }, [currentPage]);

    const saveProject = (project: Project) => {
      //console.log(`Saving project: ${project}`);
    //   let updatedProjects = projects.map((p: Project) => {
    //     return (p.id === project.id) ? project : p;
    //   });
    //   setProjects(updatedProjects);
      //console.log(updatedProjects);

      projectAPI.put(project)
        .then((updatedProject) => {
            const updatedProjects = projects.map((p: Project) => {
                return (p.id === project.id) ? new Project(updatedProject) : p;
            });
            setProjects(updatedProjects);
        })
        .catch((ex)=> {
            if(ex instanceof Error){
                setError(ex.message);
            }
        });
    };

    const deleteProject = (id: number | undefined) => {
        if(id === undefined)
            return;
        projectAPI.delete(id)
            .then((deletedProject)=>{
                const updatedProjects = projects.filter((p) => p.id !== deletedProject.id)
                setProjects(updatedProjects);
            })
            .catch((ex)=> {
            if(ex instanceof Error){
                setError(ex.message);
            }
        });
    }

    return(
        <>
            <h1>
                Projects
            </h1>
            {/* <pre>
                {JSON.stringify(MOCK_PROJECTS, null , ' ')}
            </pre> */}
            {
                error && (
                    <div className="row">
                        <div className="card large error">
                            <section>
                                <p>
                                    <span className="icon-alert inverse"></span>
                                    {error}
                                </p>
                            </section>
                        </div>
                    </div>
                )
            }
            {/* <ProjectList projects={MOCK_PROJECTS} onSave={saveProject} /> */}
            <ProjectList projects={projects} onSave={saveProject} onDelete={deleteProject} />
            {
                !loading && !error && (
                    <div className="row">
                        <div className="col-sm-12">
                            <div className="button-group fluid">
                                <button className="button default" onClick={handleMoreClick}>
                                    More Projects...
                                </button>
                            </div>
                        </div>
                    </div>
                )
            }
            {
                loading && (
                    <div className="center-page">
                        <span className="spinner primary"></span>
                        <p>Loading...</p>
                    </div>
                )
            }
        </>
    );
}
export default ProjectsPage;