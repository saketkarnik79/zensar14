import { useEffect, useState } from "react";
import { projectAPI } from "./projectAPI";
import ProjectDetail from "./ProjectDetail";
import { Project } from "./Project";
import { useParams } from "react-router";

function ProjectPage(){
    const [loading, setLoading] = useState(false);
    const [project, setProject] = useState<Project | null>(null);
    const [error, setError] = useState<string | null>(null);
    const paramas = useParams();
    const id = Number(paramas.id);

    useEffect(() => {
        setLoading(true);
        projectAPI.find(id)
            .then((data) => {
                setProject(data);
                setLoading(false);
            })
            .catch((ex) => {
                setError(ex);
                setLoading(false);
            });
    }, [id]);

    return(
        <>
            <h1>Project Detail</h1>
            <hr/>
            {
                loading && (
                    <div className="center-page">
                        <span className="spinner primary"></span>
                        <p>Loading...</p>
                    </div>
                )
            }

            <div className="row">
                {
                    error && (
                        <div className="card large error">
                            <section>
                                <p>
                                    <span className="icon-alert inverse"></span>
                                    { error }
                                </p>
                            </section>
                        </div>
                    )
                }
            </div>

            {
                project && (
                    <ProjectDetail project={project} />
                )
            }
        </>
    );
}

export default ProjectPage;