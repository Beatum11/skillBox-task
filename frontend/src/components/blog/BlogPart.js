import React from "react";
import { useGetBlogPostsQuery } from "../../store/apiSlices/blogPostsApi";
import BlogItem from "./BlogItem";
import Headline from "../elements/Headline";
import "../../css-files/css-blog/blog-part.css";

const BlogPart = () => {
  const { data: blogPosts, isLoading, isError, error } = useGetBlogPostsQuery();

  if (isLoading) {
    return <div>Loading...</div>;
  }

  if (isError) {
    return <div>{error.message}</div>;
  }

  const finalPosts = blogPosts.map((blog) => (
    <li key={blog.id}>
      <BlogItem
        date={blog.created}
        img={blog.image}
        title={blog.title}
        content={blog.content}
      />
    </li>
  ));

  return (
    <div className="blogPart-container con-size">
      <Headline text={'Our Blog:'}/>
      <ul>{finalPosts}</ul>
    </div>
  );
};

export default BlogPart;
