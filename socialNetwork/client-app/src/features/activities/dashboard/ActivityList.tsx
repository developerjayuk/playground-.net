import React, { Fragment } from "react";
import { Header } from "semantic-ui-react";
import { observer } from "mobx-react-lite";
import { useStore } from "../../../app/stores/store";
import ActivityListItem from "./ActivityListItem";

export default observer(function ActivityList() {
  const { activityStore } = useStore();
  const { groupedActivities } = activityStore;

  return (
    <>
      {groupedActivities.map(([group, activities]) => (
        <Fragment key={group}>
          <Header sub color="red">
            {group}
          </Header>
          {activities.map((activity) => (
            <ActivityListItem activity={activity} key={activity.id} />
          ))}
        </Fragment>
      ))}
    </>
  );
});
