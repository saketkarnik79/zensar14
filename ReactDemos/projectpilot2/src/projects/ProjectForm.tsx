import './projectForm.css';
import { Project } from './Project';
import { useState, type SyntheticEvent } from 'react';

import { useDispatch } from 'react-redux';
import { saveProject } from './state/projectActions';
import { type ThunkDispatch } from 'redux-thunk';
import { type ProjectState } from './state/projectTypes';
import { type AnyAction } from 'redux';

// interface ProjectFormProps{
//     onSave: (project: Project) => void;
//     onCancel: () => void;
// }

interface ProjectFormProps{
    project: Project
    //onSave: (project: Project) => void;
    onCancel: () => void;
}

//function ProjectForm(){
//function ProjectForm({onCancel}: ProjectFormProps){
//function ProjectForm({onSave, onCancel}: ProjectFormProps){
//function ProjectForm({project: initialProject, onSave, onCancel}: ProjectFormProps){
function ProjectForm({project: initialProject, onCancel}: ProjectFormProps){

    const [project, setProject] = useState(initialProject);

    const [errors, setErrors] = useState({
        name: '',
        description: '',
        budget: ''
    });

    // eslint-disable-next-line @typescript-eslint/no-explicit-any
    const dispatch = useDispatch<ThunkDispatch<ProjectState, any, AnyAction>>();

    const handleSubmit = (event: SyntheticEvent) => {
        event.preventDefault();
        //onSave(new Project({name: 'Updated Project'}));
        if(!isValid()){
            return;
        }
        //onSave(project);
        dispatch(saveProject(project));
    };

    // eslint-disable-next-line @typescript-eslint/no-explicit-any
    const handleChange = (event: any) => {
        const {type, name, value, checked} = event.target;

        let updatedValue = ( (type === 'checkbox') ? checked : value );

        //if input type is number, convert the updatedValue string to a number
        if(type==='number'){
            updatedValue = Number(updatedValue);
        }

        const change={
            [name]: updatedValue
        };

        let updatedProject: Project;
        setProject((p) => {
            updatedProject = new Project({...p, ...change});
            return updatedProject;
        });
        setErrors(() => 
            validate(updatedProject)
        );
    }

    function validate(project: Project){
        // eslint-disable-next-line @typescript-eslint/no-explicit-any
        const errors: any = { name: '', description: '', budget: ''};

        if(project.name.length === 0){
            errors.name = 'Name is required.';
        }        
        if(project.name.length>0 && project.name.length < 3){
            errors.name = 'Name need to be at least 3 characters.';
        }
        if(project.description.length === 0){
            errors.description = 'Description is required.';
        }  
        if(project.budget === 0){
            errors.budget = 'Budget must be more than $0.';
        }  
        return errors;
    }

    function isValid(){
        return (
            errors.name.length === 0 && errors.description.length === 0 && errors.budget.length === 0
        );
    }

    return(
        <>
            {/* <form className="input-group vertical" > */}
            <form className="input-group vertical" onSubmit={handleSubmit}>
                <label htmlFor="name">Project Name</label>
                <input type="text" name="name" placeholder="Enter project name"
                    value = {project.name} onChange={handleChange}
                />
                {
                    errors.name.length > 0 && (
                        <div className='card error'>
                            <p>{errors.name}</p>
                        </div>
                    )
                }
                <label htmlFor="decription">Project Description</label>
                <textarea name="description" placeholder="Enter project description" 
                    value = {project.description} onChange={handleChange}
                />
                {
                    errors.description.length > 0 && (
                        <div className='card error'>
                            <p>{errors.description}</p>
                        </div>
                    )
                }
                <label htmlFor="budget">Project Budget</label>
                <input type="number" name="budget" placeholder="Enter project budget" 
                    value = {project.budget} onChange={handleChange}
                />
                {
                    errors.budget.length > 0 && (
                        <div className='card error'>
                            <p>{errors.budget}</p>
                        </div>
                    )
                }
                <label htmlFor="isActive">Active?</label>
                <input type="checkbox" name="isActive" placeholder="Is Active?" 
                    checked = {project.isActive} onChange={handleChange}
                />
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