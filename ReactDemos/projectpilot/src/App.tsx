import './App.css';
import ProjectsPage from './projects/ProjectsPage';
import { BrowserRouter, Routes, Route, NavLink } from 'react-router-dom';
import HomePage from './home/HomePage';
import ProjectPage from './projects/ProjectPage';

function App() {
  // return (
  //   <>
  //     <div>
  //       {/* <h1>
  //         Ready for React Development
  //       </h1> */}
  //       {/* <blockquote cite="Benjamin Franklin">
  //         Tell me & I forget, teach me & I may remember, involve me & I learn.
  //       </blockquote> */}
  //       <div className='container'>
  //         <ProjectsPage/>
  //       </div>
  //     </div>
  //   </>
  // )

  return(
    <>
      <BrowserRouter>
        <header className='sticky'>
          <span className='logo'>
            <img src = '/assets/logo-3.svg' alt = 'Logo' width = '49' height = '99' />
            <NavLink to = "/" className="button rounded">
              <span className='icon-home'></span>
              Home
            </NavLink>
            <NavLink to = "/projects" className="button rounded">
              Projects
            </NavLink>
          </span>
        </header>
        <div className='container'>
          <Routes>
            <Route path='/' element={<HomePage />} />
            <Route path='/projects' element={<ProjectsPage />} />
            <Route path='/projects/:id' element={<ProjectPage />} />
          </Routes>
        </div>
      </BrowserRouter>
    </>
  );
}

export default App
