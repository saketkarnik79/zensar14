import { Project } from "./Project";
import { Link } from "react-router";

function formatDescription(description: string): string{
    return `${description.substring(0, 60)}...`;
}

// interface ProjectCardProps{
//     project: Project;
// }

interface ProjectCardProps{
    project: Project;
    onEdit: (project: Project)=> void;
    //onDelete: (id: number | undefined) => void;
}

//function ProjectCard({project}: ProjectCardProps){
//function ProjectCard({project, onEdit, onDelete}: ProjectCardProps){
function ProjectCard({project, onEdit}: ProjectCardProps){
    
    const handleEditClick = (projectBeingEdited: Project) => {
        //console.log(projectBeingEdited);
        onEdit(projectBeingEdited);
    };

    // const handleDeleteClick = (id: number | undefined) =>{
    //     onDelete(id);
    // };

    return(
        <>
            <div className="card">
                <img src = { project.imageUrl} alt = {project.name} />
                <section className="section dark">

                    <Link to = {`/projects/${project.id}`}>
                        <h5 className="strong">
                            <strong>{project.name}</strong>
                        </h5>
                        <p>{formatDescription(project.description)}</p>
                        <p><strong>Budget:</strong> {project.budget.toLocaleString()}</p>
                    </Link>
                    <button className=" bordered" onClick={() => handleEditClick(project)}>
                        <span className="icon-edit"></span>
                        Edit
                    </button>
                    <span></span>
                    {/* <button className=" bordered primary" onClick={() => handleDeleteClick(project.id)}>
                        <i className="fa fa-trash"></i>
                        Delete
                    </button> */}
                </section>
            </div>
        </>
    );
}

export default ProjectCard;