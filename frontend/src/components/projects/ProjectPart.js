// This component is responsible for displaying projects on the main site.
import React from "react";
import { useGetProjectsQuery } from "../../store/apiSlices/projectsApi";
import ProjectItem from "./ProjectItem";
import Headline from "../elements/Headline";
import { useNavigate } from "react-router-dom";
import "../../css-files/css-projects/project-part.css";


const ProjectPart = () => {
  const { data: projects, isLoading, isError, error } = useGetProjectsQuery();
  const navigate = useNavigate();

  if (isLoading) {
    return <div>Loading...</div>;
  }

  // If there was an error
  if (isError) {
    return <div>{error.message}</div>;
  }

  const openProjectHandler = ({ _title, _description, _img }) => {
    navigate("/project", {
      state: {
        title: _title,
        description: _description,
        img: _img,
      },
    });
  };

  const finalProjects = projects.map((project) => {
    return (
      <li key={project.id}>
        <ProjectItem
          title={project.title}
          imgUrl={project.cover}
          clickHandler={() =>
            openProjectHandler({
              _title: project.title,
              _description: project.description,
              _img: project.cover,
            })
          }
        />
      </li>
    );
  });

  return (
    <div className="projectPart-container con-size small-con">
      <Headline text={'Our Projects:'}/>
      <ul className="projects-list">{finalProjects}</ul>
    </div>
  );
};

export default ProjectPart;
