import './projectForm.css';
import { Project } from './Project';
import type { SyntheticEvent } from 'react';

interface ProjectFormProps{
    onSave: (project: Project) => void;
    onCancel: () => void;
}

//function ProjectForm(){
//function ProjectForm({onCancel}: ProjectFormProps){
function ProjectForm({onSave, onCancel}: ProjectFormProps){

    const handleSubmit = (event: SyntheticEvent) => {
        event.preventDefault();
        onSave(new Project({name: 'Updated Project'}));
    };

    return(
        <>
            {/* <form className="input-group vertical" > */}
            <form className="input-group vertical" onSubmit={handleSubmit}>
                <label htmlFor="name">Project Name</label>
                <input type="text" name="name" placeholder="Enter project name" />
                <label htmlFor="decription">Project Description</label>
                <textarea name="description" placeholder="Enter project description" />
                <label htmlFor="budget">Project Budget</label>
                <input type="number" name="budget" placeholder="Enter project budget" />
                <label htmlFor="isActive">Active?</label>
                <input type="checkbox" name="isActive" placeholder="Is Active?" />
                <div className="input-group">
                    <button className="primary bordered medium">Save</button>
                    <span/>
                    <button type="button" className="bordered medium" onClick={onCancel}>Cancel</button>
                </div>
            </form>
        </>
    );
}

export default ProjectForm;