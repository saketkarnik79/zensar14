import { Project } from "./Project";
import ProjectCard from "./ProjectCard";
import ProjectForm from "./ProjectForm";
import { useState } from "react";

// interface ProjectListProps{
//     projects: Project[];
// }

interface ProjectListProps{
    projects: Project[];
    //onSave: (project: Project) => void;
    //onDelete: (id: number | undefined) => void;
}

//function ProjectList({projects}: ProjectListProps){
//function ProjectList({projects, onSave, onDelete}: ProjectListProps){
function ProjectList({projects}: ProjectListProps){

    const [projectBeingEdited, setProjectBeingEdited] = useState({});

    const handleEdit = (project: Project)=>{
        //console.log(project);
        setProjectBeingEdited(project);
    };

    const cancelEditing = () => {
        setProjectBeingEdited({});
    };

    return (
        <>
            {/* <pre>
                {JSON.stringify(projects, null, ' ')}
            </pre> */}

            {/* <ul className="row">
                {
                    projects.map((project)=> (
                        <li key={project.id}>{project.name}</li>
                    ))
                }
            </ul> */}

            <div className="row">
                {
                    projects.map((project)=>(
                        <div key={project.id} className="cols-sm">
                            {/* <div className="card">
                                <img src = {project.imageUrl} alt = {project.name} />
                                <section className="section dark">
                                    <h5 className="strong">
                                        <strong>{project.name}</strong>
                                    </h5>
                                    <p>{project.description}</p>
                                    <p><strong>Budget:</strong> {project.budget.toLocaleString()}</p>
                                </section>
                            </div> */}

                            {/* <ProjectCard project={project} onEdit={handleEdit}/>
                            <ProjectForm /> */}

                            {
                                project === projectBeingEdited ? (
                                    // <ProjectForm project={project} onCancel={cancelEditing} onSave={onSave}/>
                                    <ProjectForm project={project} onCancel={cancelEditing} />
                                ) : (
                                    // <ProjectCard project={project} onEdit={handleEdit} onDelete={onDelete}/>
                                    <ProjectCard project={project} onEdit={handleEdit} />
                                )
                            }
                        </div>
                    ))
                }
            </div>
        </>
    );
}

export default ProjectList;